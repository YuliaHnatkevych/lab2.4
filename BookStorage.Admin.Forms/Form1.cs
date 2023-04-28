using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStorage.Domain.Repositories.Abstract;
using BookStorage.Domain.Enums;
using BookStorage.Domain.Factories;
using BookStorage.Domain.Loggers;
using BookStorage.Domain.Models;

namespace BookStorage.Admin.Forms
{
    public partial class Form1 : Form
    {
        private readonly IERepository ebookRepository;
        private readonly IPaperRepository paperRepository;
        private int index;

        //створення об'єкту інтерфейсу через фабрику
        public Form1()
        {
            var factoryProvider = new FactoryProvider(FactoryType.Txt);
            var factory = factoryProvider.GetRepositoryFactory();

            ebookRepository = factory.GetERepository();
            paperRepository = factory.GetPaperRepository();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadBooks();
            ReloadPaperBooks();
        }

        private void ReloadBooks()
        {
            var eBooks = ebookRepository.GetAll();
            var searchName = tbSearchName.Text;
            if (!string.IsNullOrEmpty(searchName))
            {
                //filter
                eBooks = eBooks.Where(ebook => ebook.Name == searchName).ToArray();
            }

            var filteredeBooks = eBooks
                .Select(ebook => new
            {
                ebook.Name,
                ebook.Publisher,
                ebook.NumberOfPages,
                ebook.Year,
                ebook.LinkOnBook,
                ebook.BookFormat,
                Price = ebook.NumberOfPages > 300 ? 720 : (ebook.NumberOfPages > 200 ? 440 : 270)
            })
                .OrderBy(ebook => ebook.Name) //sorting
                .ToArray();
            lbTotalPrice.Text = $"{filteredeBooks.Sum(ebook => ebook.Price)}₴";
            lbMaxPages.Text = $"{filteredeBooks.Max(ebook => ebook.NumberOfPages)}₴";
            lbMinPages.Text = $"{filteredeBooks.Min(ebook => ebook.NumberOfPages)}₴";
            
                dataGridView1.DataSource = filteredeBooks;
        }
        
        private void ReloadPaperBooks()
        {
            var paperBooks = paperRepository.GetAll();
            var searchName = tbSearchU.Text;
            if (!string.IsNullOrEmpty(searchName))
            {
                //filter
                paperBooks = paperBooks.Where(paperbook => paperbook.Name == searchName).ToArray();
            }

            var filteredpaperBooks = paperBooks
                .Select(paperbook => new
                {
                    paperbook.Name,
                    paperbook.Publisher,
                    paperbook.NumberOfPages,
                    paperbook.Year,
                    paperbook.Format,
                    paperbook.Weight,
                    Price = paperbook.NumberOfPages > 300 ? 430 : (paperbook.NumberOfPages > 200 ? 210 : 270)
                })
                .OrderBy(paperbook => paperbook.Name) //sorting
                .ToArray();
            lbTotalPriceU.Text = $"{filteredpaperBooks.Sum(paperbook => paperbook.Price)}₴";
            lbMaxPagesU.Text = $"{filteredpaperBooks.Max(paperbook => paperbook.NumberOfPages)}";
            lbMinPagesU.Text = $"{filteredpaperBooks.Min(paperbook => paperbook.NumberOfPages)}";
            
            dataGridView2.DataSource = filteredpaperBooks;
        }

        private void addEBook_Click(object sender, EventArgs e)
        {
            try
            {
                OnAddNewBookUnsafe();
                MessageBox.Show("Your book added succesfully :)", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                TxtLogger.GetLogger().LogError($"Winforms (Admin) Error: {ex.Message}");
                MessageBox.Show("Some error occurs during adding the book :(", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        private void addPaperBook_Click(object sender, EventArgs e)
        {
            try
            {
                OnAddNewBookUnsafeU();
                MessageBox.Show("Your book added succesfully :)", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                TxtLogger.GetLogger().LogError($"Winforms (Admin) Error: {ex.Message}");
                MessageBox.Show("Some error occurs during adding the book :(", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OnAddNewBookUnsafe()
        {
            var name = tbName.Text;
            var publisher = tbPublisher.Text;
            var year = Convert.ToInt32(tbYear.Text);
            var numberOfPages = Convert.ToInt32(tbPages.Text);
            var linkOnBook = tbAddLink.Text;
            var bookFormat = tbAddBookFormat.Text;

            ebookRepository.Add(new EBook
            {
                Name = name,
                Publisher = publisher,
                Year = year,
                NumberOfPages = numberOfPages,
                LinkOnBook = linkOnBook,
                BookFormat = bookFormat
            });

            ReloadBooks();
        }
        
        private void OnAddNewBookUnsafeU()
        {
            var name = tbNameU.Text;
            var publisher = tbPublisherU.Text;
            var year = Convert.ToInt32(tbYearU.Text);
            var numberOfPages = Convert.ToInt32(tbPagesU.Text);
            var format = tbFormatU.Text;
            var weight = Convert.ToSingle(tbWeightU.Text);

            paperRepository.Add(new PaperBook
            {
                Name = name,
                Publisher = publisher,
                Year = year,
                NumberOfPages = numberOfPages,
                Format = format,
                Weight = weight
            });

            ReloadPaperBooks();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                OnRemoveBookUnsafe();
                MessageBox.Show("Your book deleted succesfully :)", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                TxtLogger.GetLogger().LogError($"Winforms (Admin) Error: {ex.Message}");
                MessageBox.Show("Some error occurs during deleting the book :(", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OnRemoveBookUnsafe()
        {
            ebookRepository.Delete(new EBook(), index);

            ReloadBooks();
        }
        
        private void OnRemoveBookUnsafeU()
        {
            paperRepository.Delete(new PaperBook(), index);

            ReloadPaperBooks();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            var bookRow = dataGridView1.SelectedRows[0];
            tbRemoveName.Text = bookRow.Cells[0].Value.ToString();
            tbRemovePublisher.Text = bookRow.Cells[1].Value.ToString();
            tbRemovePages.Text = bookRow.Cells[2].Value.ToString();
            tbRemoveYear.Text = bookRow.Cells[5].Value.ToString();
            tbRemoveLink.Text = bookRow.Cells[3].Value.ToString();
            tbRemoveBookFormat.Text = bookRow.Cells[4].Value.ToString();
            index = bookRow.Index;

        }
        
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return;
            var bookRow = dataGridView2.SelectedRows[0];
            tbRemoveNameU.Text = bookRow.Cells[0].Value.ToString();
            tbRemovePublisherU.Text = bookRow.Cells[1].Value.ToString();
            tbRemovePagesU.Text = bookRow.Cells[2].Value.ToString();
            tbRemoveFormatU.Text = bookRow.Cells[3].Value.ToString();
            tbRemoveWeightU.Text = bookRow.Cells[4].Value.ToString();
            tbRemoveYearU.Text = bookRow.Cells[5].Value.ToString();
            index = bookRow.Index;

        }

        private void RemoveU_Click(object sender, EventArgs e)
        {
            try
            {
                OnRemoveBookUnsafeU();
                MessageBox.Show("Your book deleted succesfully :)", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                TxtLogger.GetLogger().LogError($"Winforms (Admin) Error: {ex.Message}");
                MessageBox.Show("Some error occurs during deleting the book :(", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadBooks();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReloadPaperBooks();
        }
    }
}