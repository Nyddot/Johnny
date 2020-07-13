using System;
using System.IO;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Johnny {
    class Program {

        static DirectoryInfo diretorio = new DirectoryInfo(@"C:\Users\vinicius.waltrick\Documents\Johnny\");
        static string destinoPDF = @"C:\Users\vinicius.waltrick\Documents\relatoriopdf.pdf";
        static PdfDocument pdfDoc = new PdfDocument(new PdfWriter(destinoPDF));
        static Document doc = new Document(pdfDoc);
        static string relatorio = "";

        static void AlteraTexto(String arquivo) {
            
            string diretorio = arquivo;

            if (File.ReadAllText(diretorio).Contains("[nomeproprio]")) {
                string textoAntes = File.ReadAllText(diretorio);

                Console.WriteLine("Arquivo antes de ser sobreescrito:\n" + textoAntes);
                Console.WriteLine(@"Texto possui ""[nomeproprio]""");

                string textoDepois = File.ReadAllText(diretorio).Replace("[nomeproprio]", "Johnny C");

                File.WriteAllText(diretorio, textoDepois);
                Console.WriteLine("Arquivo depois de ser sobreescrito:\n" + textoDepois);
            }
        }

        static void MovedorImagem(FileInfo file) {

            string destinoImagem = (@"C:\Users\vinicius.waltrick\Documents\Johnny\imagem\");
            string fileNameSubstring = file.Name.Substring(0, 1);
            string destinoLetra = (@"C:\Users\vinicius.waltrick\Documents\Johnny\imagem\" + fileNameSubstring + @"\");

            if (!Directory.Exists(destinoImagem + fileNameSubstring)) {

                Directory.CreateDirectory(destinoImagem + fileNameSubstring);

                Console.WriteLine(@$"O diretório {fileNameSubstring} foi criado com sucesso!");

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o novo diretorio alfabetico com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            } else if (File.Exists(destinoLetra + file.Name)) {

                CriaDirBackup();
                string destinoBackup = @"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\";

                File.Move(Path.Combine(destinoLetra, file.Name), Path.Combine(destinoBackup,
                    file.LastAccessTime.ToString("dd-mm-yyyy hh-MM-ss") + " - " + file.Name));

                Console.WriteLine("Arquivo duplicado movido para o Backup!");

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com " +
                    $"sucesso e substituiu o arquivo deste dir");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";

            } else {

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            }
        }

        static void MovedorMusica(FileInfo file) {

            string destinoMusica = (@"C:\Users\vinicius.waltrick\Documents\Johnny\musica\");
            string fileNameSubstring = file.Name.Substring(0, 1);
            string destinoLetra = Path.Combine(@"C:\Users\vinicius.waltrick\Documents\Johnny\musica\", fileNameSubstring);

            if (!Directory.Exists(destinoMusica + fileNameSubstring)) {

                Directory.CreateDirectory(destinoMusica + fileNameSubstring);

                Console.WriteLine(@$"O diretório {fileNameSubstring} foi criado com sucesso!");

                File.Move(file.FullName, Path.Combine(destinoLetra, file.Name));

                Console.WriteLine($"{file} movido para o novo diretorio alfabetico com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";

            } else if (File.Exists(destinoLetra + file.Name)) {

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com " +
                    $"sucesso e substituiu o arquivo deste dir");

                CriaDirBackup();

                string destinoBackup = @"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\";

                File.Move(Path.Combine(destinoLetra, file.Name), Path.Combine(destinoBackup, file.LastAccessTime.ToString("dd-mm-yyyy hh-MM-ss") + " - " + file.Name));

                Console.WriteLine("Arquivo duplicado movido para o Backup!");

                File.Move(file.FullName, Path.Combine(destinoLetra, file.Name));

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            } else {

                File.Move(file.FullName, Path.Combine(destinoLetra, file.Name));

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            }
        }

        static void MovedorVideo(FileInfo file) {

            string destinoVideo = (@"C:\Users\vinicius.waltrick\Documents\Johnny\video\");
            string fileNameSubstring = file.Name.Substring(0, 1);
            string destinoLetra = (@"C:\Users\vinicius.waltrick\Documents\Johnny\video\" + fileNameSubstring + @"\");

            if (!Directory.Exists(destinoVideo + fileNameSubstring)) {

                Directory.CreateDirectory(destinoVideo + fileNameSubstring);

                Console.WriteLine(@$"O diretório {fileNameSubstring} foi criado com sucesso!");

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o novo diretorio alfabetico com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";

            } else if (File.Exists(destinoLetra + file.Name)) {

                CriaDirBackup();
                string destinoBackup = @"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\";

                File.Move(Path.Combine(destinoLetra, file.Name), Path.Combine(destinoBackup,
                    file.LastAccessTime.ToString("dd-mm-yyyy hh-MM-ss") + " - " + file.Name));

                Console.WriteLine("Arquivo duplicado movido para o Backup!");

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com " +
                    $"sucesso e substituiu o arquivo deste dir");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            } else {

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            }
        }

        static void MovedorResto(FileInfo file) {

            string destinoResto = @"C:\Users\vinicius.waltrick\Documents\Johnny\resto\";
            string fileNameSubstring = file.Name.Substring(0, 1);
            string destinoLetra = (@"C:\Users\vinicius.waltrick\Documents\Johnny\resto\" + fileNameSubstring + @"\");

            if (!Directory.Exists(destinoResto + fileNameSubstring)) {

                Directory.CreateDirectory(destinoResto + fileNameSubstring);

                Console.WriteLine(@$"O diretório {fileNameSubstring} foi criado com sucesso!");

                File.Move(file.FullName, destinoLetra + file.Name);

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            } else if (File.Exists(destinoLetra + file.Name)) {

                CriaDirBackup();
                string destinoBackup = @"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\";

                File.Move(Path.Combine(destinoLetra, file.Name), Path.Combine(destinoBackup,
                    file.LastAccessTime.ToString("dd-mm-yyyy hh-MM-ss") + " - " + file.Name));

                Console.WriteLine("Arquivo duplicado movido para o Backup!");

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com " +
                    $"sucesso e substituiu o arquivo deste dir");
                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";

            } else {

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            }
        }

        static void MovedorTexto(FileInfo file) {

            string destinoTexto = @"C:\Users\vinicius.waltrick\Documents\Johnny\texto\";
            string fileNameSubstring = file.Name.Substring(0, 1);
            string destinoLetra = (@"C:\Users\vinicius.waltrick\Documents\Johnny\texto\" + fileNameSubstring + @"\");

            AlteraTexto(file.FullName);

            if (!Directory.Exists(destinoTexto + fileNameSubstring)) {

                Directory.CreateDirectory(destinoTexto + fileNameSubstring);

                Console.WriteLine(@$"O diretório {fileNameSubstring} foi criado com sucesso!");

                File.Move(file.FullName, destinoLetra + file.Name);

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";

            } else if (File.Exists(destinoLetra + file.Name)) {

                CriaDirBackup();

                string destinoBackup = @"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\";

                File.Move(Path.Combine(destinoLetra, file.Name), Path.Combine(destinoBackup,
                    file.LastAccessTime.ToString("dd-mm-yyyy hh-MM-ss") + " - " + file.Name));

                Console.WriteLine("Arquivo duplicado movido para o Backup!");

                File.Move(file.FullName, destinoLetra + file.Name);
                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com " +
                    $"sucesso e substituiu o arquivo deste dir");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            } else {

                File.Move(file.FullName, destinoLetra + file.Name);

                Console.WriteLine($"{file} movido para o diretorio alfabetico já existente com sucesso");

                relatorio = relatorio + "\n" + $"{file.Name} -- LWT: {file.LastWriteTime}";
            }
        }
        static void MoveMusica() {

            foreach (FileInfo file in diretorio.GetFiles("*.mp3")) {
                MovedorMusica(file);
            }
            foreach (FileInfo file in diretorio.GetFiles("*.wav")) {
                MovedorMusica(file);
            }
            foreach (FileInfo file in diretorio.GetFiles("*.wma")) {
                MovedorMusica(file);
            }
        }

        static void MoveImagem() {

            foreach (FileInfo file in diretorio.GetFiles("*.pdf")) {
                MovedorImagem(file);
            }

            foreach (FileInfo file in diretorio.GetFiles("*.gif")) {
                MovedorImagem(file);
            }

            foreach (FileInfo file in diretorio.GetFiles("*.png")) {
                MovedorImagem(file);
            }
        }

        static void MoveVideo() {

            foreach (FileInfo file in diretorio.GetFiles("*.mp4")) {
                MovedorVideo(file);
            }
            foreach (FileInfo file in diretorio.GetFiles("*.mkv")) {
                MovedorVideo(file);
            }
        }

        static void MoveResto() {

            foreach (FileInfo file in diretorio.GetFiles("*.rar")) {
                MovedorResto(file);
            }
            foreach (FileInfo file in diretorio.GetFiles("*.zip")) {
                MovedorResto(file);
            }
            foreach (FileInfo file in diretorio.GetFiles("*.msi")) {
                MovedorResto(file);
            }
        }

        static void MoveTexto() {

            foreach (FileInfo file in diretorio.GetFiles("*.txt")) {
                MovedorTexto(file);
            }

            foreach (FileInfo file in diretorio.GetFiles("*.xml")) {
                MovedorTexto(file);
            }

            foreach (FileInfo file in diretorio.GetFiles("*.html")) {
                MovedorTexto(file);
            }
            foreach (FileInfo file in diretorio.GetFiles("*.csv")) {
                MovedorTexto(file);
            }
            ManipulaPdf(relatorio);
        }

        static void CriaDirMusica() {

            string destinoMusica = (@"C:\Users\vinicius.waltrick\Documents\Johnny\musica\");
            if (Directory.Exists(destinoMusica)) {
                Console.WriteLine(@"O diretório ""musica"" já existe!");
                MoveMusica();
            } else {

                DirectoryInfo dir = new DirectoryInfo(diretorio.ToString());

                FileInfo[] arquivosMp3 = dir.GetFiles("*.mp3");
                FileInfo[] arquivosWav = dir.GetFiles("*.wav");
                FileInfo[] arquivosWma = dir.GetFiles("*.wma");

                if (arquivosMp3.Length > 0
                    || arquivosWav.Length > 0
                    || arquivosWma.Length > 0) {
                    Directory.CreateDirectory(destinoMusica);

                    Console.WriteLine(@"Diretório ""musica"" criado com sucesso!");
                    MoveMusica();
                } else {
                    Console.WriteLine(@"Não há arquivos para criar a pasta ""musica""");
                }
            }
        }


        static void CriaDirImagem() {

            string destinoImagem = (@"C:\Users\vinicius.waltrick\Documents\Johnny\imagem\");

            if (Directory.Exists(destinoImagem)) {
                Console.WriteLine(@"O diretório ""imagem"" já existe");
                MoveImagem();

            } else {

                DirectoryInfo dir = new DirectoryInfo(diretorio.ToString());

                FileInfo[] arquivosTxt = dir.GetFiles("*.txt");
                FileInfo[] arquivosXml = dir.GetFiles("*.xml");
                FileInfo[] arquivosHtml = dir.GetFiles("*.html");
                FileInfo[] arquivosCsv = dir.GetFiles("*.csv");

                if (arquivosTxt.Length > 0
                    || arquivosCsv.Length > 0
                    || arquivosHtml.Length > 0
                    || arquivosXml.Length > 0) {
                    Directory.CreateDirectory(destinoImagem);

                    Console.WriteLine(@"Diretório ""imagem"" criado com sucesso!");
                    MoveImagem();
                } else {
                    Console.WriteLine(@"Não há arquivos para criar a pasta ""imagem""");
                }
            }
        }

        static void CriaDirVideo() {

            string destinoVideo = (@"C:\Users\vinicius.waltrick\Documents\Johnny\video\");
            if (Directory.Exists(destinoVideo)) {
                Console.WriteLine(@"O diretório ""Video"" já existe");
                MoveVideo();
            } else {

                DirectoryInfo dir = new DirectoryInfo(diretorio.ToString());

                FileInfo[] arquivosMp3 = dir.GetFiles("*.mp4");
                FileInfo[] arquivosWav = dir.GetFiles("*.mkv");

                if (arquivosMp3.Length > 0
                    || arquivosWav.Length > 0) {

                    Directory.CreateDirectory(destinoVideo);

                    Console.WriteLine(@"Diretório ""video"" criado com sucesso!");
                    MoveVideo();
                } else {
                    Console.WriteLine(@"Não há arquivos para criar a pasta ""video""");
                }
            }
        }

        static void CriaDirResto() {

            string destinoResto = (@"C:\Users\vinicius.waltrick\Documents\Johnny\resto\");

            if (Directory.Exists(destinoResto)) {
                Console.WriteLine(@"O diretório ""resto"" já existe");
                MoveResto();

            } else {

                DirectoryInfo dir = new DirectoryInfo(diretorio.ToString());

                FileInfo[] arquivosRar = dir.GetFiles("*.rar");
                FileInfo[] arquivosZip = dir.GetFiles("*.zip");
                FileInfo[] arquivosMsi = dir.GetFiles("*.msi");

                if (arquivosRar.Length > 0
                    || arquivosZip.Length > 0
                    || arquivosMsi.Length > 0) {
                    Directory.CreateDirectory(destinoResto);

                    Console.WriteLine(@"Diretório ""resto"" criado com sucesso!");
                    MoveResto();
                } else {
                    Console.WriteLine(@"Não há arquivos para criar a pasta ""musica""");
                }
            }
        }

        static void CriaDirTexto() {

            string destinoTexto = @"C:\Users\vinicius.waltrick\Documents\Johnny\texto\";

            if (Directory.Exists(destinoTexto)) {
                Console.WriteLine(@"O diretório ""texto"" já existe!");
                MoveTexto();
            } else {
                DirectoryInfo dir = new DirectoryInfo(diretorio.ToString());

                FileInfo[] arquivosTxt = dir.GetFiles("*.txt");
                FileInfo[] arquivosXml = dir.GetFiles("*.xml");
                FileInfo[] arquivosHtml = dir.GetFiles("*.html");
                FileInfo[] arquivosCsv = dir.GetFiles("*.csv");

                if (arquivosTxt.Length > 0
                    || arquivosXml.Length > 0
                    || arquivosHtml.Length > 0
                    || arquivosCsv.Length > 0) {
                    Directory.CreateDirectory(destinoTexto);

                    Console.WriteLine(@"Diretório ""texto"" criado com sucesso!");
                    MoveTexto();
                } else {
                    Console.WriteLine(@"Não há arquivos para criar a pasta ""texto""");
                }
            }
        }

        static void CriaDirBackup() {

            if (!Directory.Exists(@"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\")) {
                Directory.CreateDirectory(@"C:\Users\vinicius.waltrick\Documents\Johnny\Backup\");
                Console.WriteLine("Diretório Backup criado com sucesso!");
            }
        }

        static void ManipulaPdf(String paragrafo) {

            if (!File.Exists(destinoPDF)) {
                FileInfo file = new FileInfo(destinoPDF);
                file.Directory.Create();
            }

            Table table = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();

            Paragraph paragraph = new Paragraph("Relatório de movimentação");
            paragraph.SetTextAlignment(TextAlignment.CENTER);
            Paragraph paragraph2 = new Paragraph($"{paragrafo}");

            doc.Add(paragraph);
            doc.Add(paragraph2);
            doc.Add(table);
            doc.Close();
            Console.WriteLine("\nPDF criado/atualizado com sucesso!\n");
        }

        static void Main(string[] args) {

            Console.WriteLine("Iniciando o procedimento de organização de arquivos");
            CriaDirImagem();
            CriaDirMusica();
            CriaDirVideo();
            CriaDirResto();
            CriaDirTexto();
        }
    }
}