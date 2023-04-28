using System;
using System.Collections.Generic;
using System.IO;
using BookStorage.Domain.Convertors.Txt;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Txt
{
    internal class TxtBaseRepository<T> : IRepository<T> // Generic type
    {
        private List<T> _items;
        private string _sourceFileName;
        private ITxtConvertor<T> _convertor;

        public TxtBaseRepository(string sourceFileName, ITxtConvertor<T> convertor)
        {
            _items = new List<T>();
            _sourceFileName = sourceFileName;
            _convertor = convertor;
        }

        public void Add(T item)
        {
            _items.Add(item);
            WriteItemsToFile();
        }

        public void Delete(T item, int index)
        {
            
            _items.RemoveAt(index);
            WriteItemsToFile();

        }

        /// <summary>
        /// Call Count method after GetAll method to have all data sync
        /// </summary>
        public int Count()
        {
            return _items.Count;
        }

        public T[] GetAll()
        {
            ReadItemsFromFile();
            return _items.ToArray();
        }

        private void ReadItemsFromFile()
        {
            _items.Clear();

            using (var sr = new StreamReader(_sourceFileName)) // try - finally
            {
                var lines = sr.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                    _items.Add(_convertor.Convert(line));

            }
        }

        private void WriteItemsToFile()
        {
            using (var sw = new StreamWriter(_sourceFileName))
            {
                foreach (var item in _items)
                {
                    sw.WriteLine(_convertor.Convert(item));
                }
            }
        }
    }
}