using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    //Chain of Responsibility Pattern, istemci ve hedef nesne arasında birden fazla nesnenin bir dizi şeklinde düzenlendiği ve her nesnenin belirli bir sorumluluk üstlendiği bir davranışsal tasarım kalıbıdır. İstek, zincirdeki nesneler arasında ilerler ve her nesne, isteği işleyip sonuç döndürebilir veya işlemi sonraki nesneye devredebilir. Bu, istemcinin hedef nesneyi doğrudan çağırmak yerine, işlemin bir dizi nesne tarafından gerçekleştirileceği bir yapı sağlar.

    //Örnek olarak, bir dosya işleme sistemini düşünelim.Dosya okuma, yazma ve kopyalama işlemleri için farklı işlemcilerimiz olsun ve istekleri işlemek için bir dizi şeklinde düzenlensinler.

    //    Bu örnekte, her işlemci tipi için farklı sınıflar oluşturduk ve her işlemci, isteği işleme veya sonraki işlemciye geçme sorumluluğunu üstlenir.Bu sayede, istemci kodu işlemcilerin tam olarak nasıl çalıştığını bilmeden işlemleri gerçekleştirebilir.

    //Chain of Responsibility Pattern olmadan, istemcinin her işlemciye doğrudan erişimi olması ve her işlem için doğru işlemciyi çağırması gerekir

        public abstract class FileProcessor
        {
            protected FileProcessor Successor;

            public void SetSuccessor(FileProcessor successor)
            {
                Successor = successor;
            }

            public abstract void ProcessRequest(string operation, string fileName);
        }

        public class FileReader : FileProcessor
        {
            public override void ProcessRequest(string operation, string fileName)
            {
                if (operation == "read")
                {
                    Console.WriteLine($"Reading file: {fileName}");
                }
                else if (Successor != null)
                {
                    Successor.ProcessRequest(operation, fileName);
                }
            }
        }

        public class FileWriter : FileProcessor
        {
            public override void ProcessRequest(string operation, string fileName)
            {
                if (operation == "write")
                {
                    Console.WriteLine($"Writing file: {fileName}");
                }
                else if (Successor != null)
                {
                    Successor.ProcessRequest(operation, fileName);
                }
            }
        }

        public class FileCopier : FileProcessor
        {
            public override void ProcessRequest(string operation, string fileName)
            {
                if (operation == "copy")
                {
                    Console.WriteLine($"Copying file: {fileName}");
                }
                else if (Successor != null)
                {
                    Successor.ProcessRequest(operation, fileName);
                }
            }
        }

        class Program1
        {
            static void Main1(string[] args)
            {
                FileProcessor fileReader = new FileReader();
                FileProcessor fileWriter = new FileWriter();
                FileProcessor fileCopier = new FileCopier();

                fileReader.SetSuccessor(fileWriter);
                fileWriter.SetSuccessor(fileCopier);

                fileReader.ProcessRequest("read", "file.txt");
                fileReader.ProcessRequest("write", "file.txt");
                fileReader.ProcessRequest("copy", "file.txt");
            }
        }

}
