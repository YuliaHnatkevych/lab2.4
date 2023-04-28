using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStorage.Domain.Enums;
using BookStorage.Domain.Factories;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.User.Forms
{
    public partial class Form1 : Form
    {
        private readonly IERepository ebookRepository;
        private readonly IPaperRepository paperRepository;

        //створення об'єкту інтерфейсу через фабрику
        public Form1()
        {
            var factoryProvider = new FactoryProvider(FactoryType.Txt);
            var factory = factoryProvider.GetRepositoryFactory();

            ebookRepository = factory.GetERepository();
            paperRepository = factory.GetPaperRepository();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadBooks();
            ReloadPaperBooks();
        }
        private void ReloadBooks()
        {
            var eBooks = ebookRepository.GetAll();
            var searchName = tbSearchNameUser.Text;
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
                    // Synopsis = ebook.ToString(),
                    Price = ebook.NumberOfPages > 300 ? 720 : (ebook.NumberOfPages > 200 ? 440 : 270)
                })
                .OrderBy(ebook => ebook.Name) //sorting
                .ToArray();
            lbMaxPagesUser.Text = $"{filteredeBooks.Max(ebook => ebook.NumberOfPages)}₴";
            lbMinPagesUser.Text = $"{filteredeBooks.Min(ebook => ebook.NumberOfPages)}₴";
            
            dataGridView1.DataSource = filteredeBooks;
        }
        
        private void ReloadPaperBooks()
        {
            var paperBooks = paperRepository.GetAll();
            var searchName = tbSearchNameUser.Text;
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
            lbMaxPagesUser.Text = $"{filteredpaperBooks.Max(paperbook => paperbook.NumberOfPages)}";
            lbMinPagesUser.Text = $"{filteredpaperBooks.Min(paperbook => paperbook.NumberOfPages)}";
            
            dataGridView2.DataSource = filteredpaperBooks;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadBooks();
            ReloadPaperBooks();
        }

        private void SearchU_Click(object sender, EventArgs e)
        {
            ReloadBooks();
            ReloadPaperBooks();
        }

        private void lbMaxPagesUser_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}