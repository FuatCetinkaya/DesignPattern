using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Prototype;

internal class Alternatif
{
    //Bu sistemde, belgelerin içeriğini saklamak için önceden tanımlanmış biçimler bulunmaktadır. Bu biçimlerin her biri, bir nesnenin kopyasını alarak kullanılabilir. 


    //Bu örnekte, belge işleme sistemi için DocumentFormat adlı soyut bir sınıf oluşturduk. Bu sınıf, tüm belge formatlarında ortak olan özellikleri içerir. Türetilen LetterFormat ve ReportFormat sınıflarını kullanarak, farklı belge formatlarını temsil ettik. Clone metodu ile her belge formatının kopyasını alarak, yeni formatlar oluşturduk.

    //Bu örnek ile Prototype Pattern kullanarak, belge formatlarının kopyalarını hızlı ve etkili bir şekilde oluşturabildik.Bu sayede, belge formatlarının yönetimi ve kullanımı daha kolay ve performanslı hale geldi.Bu pattern olmadan, her belge formatı için yeni bir örnek oluşturup özelliklerini atamak zorunda kalırdık.
    public abstract class DocumentFormat
    {
        public string Name { get; set; }
        public string Font { get; set; }
        public int FontSize { get; set; }

        public DocumentFormat() { }

        public DocumentFormat(DocumentFormat source)
        {
            if (source != null)
            {
                Name = source.Name;
                Font = source.Font;
                FontSize = source.FontSize;
            }
        }

        public abstract DocumentFormat Clone();
    }

    public class LetterFormat : DocumentFormat
    {
        public LetterFormat() { }

        public LetterFormat(LetterFormat source) : base(source) { }

        public override DocumentFormat Clone()
        {
            return new LetterFormat(this);
        }
    }

    public class ReportFormat : DocumentFormat
    {
        public ReportFormat() { }

        public ReportFormat(ReportFormat source) : base(source) { }

        public override DocumentFormat Clone()
        {
            return new ReportFormat(this);
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            LetterFormat letterFormat = new LetterFormat
            {
                Name = "Letter",
                Font = "Arial",
                FontSize = 12
            };

            ReportFormat reportFormat = new ReportFormat
            {
                Name = "Report",
                Font = "Times New Roman",
                FontSize = 14
            };

            DocumentFormat letterCopy = letterFormat.Clone();
            letterCopy.Name = "Letter Copy";

            DocumentFormat reportCopy = reportFormat.Clone();
            reportCopy.Name = "Report Copy";

            List<DocumentFormat> formats = new List<DocumentFormat> { letterFormat, reportFormat, letterCopy, reportCopy };

            foreach (var format in formats)
            {
                Console.WriteLine($"Name: {format.Name}, Font: {format.Font}, Font Size: {format.FontSize}");
            }
        }
    }
}
