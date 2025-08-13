using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDrive.Models
{
    internal class FileSystemItem
    {
        public Guid Id { get; set; } // Уникальный идентификатор типа Guid
        public string Name { get; set; } // Имя файла или папки
        public bool IsFile { get; set; } // Является ли элемент файлом
        public Guid? ParentId { get; set; } // Идентификатор родительского элемента
        public string Path { get; set; } // Полный путь к элементу
        public string Extension { get; set; } // Расширение файла
        public DateTime CreationTime { get; set; } // Время создания
        public string? Icon { get; set; } // Путь к иконке или имя иконки
    }
}
