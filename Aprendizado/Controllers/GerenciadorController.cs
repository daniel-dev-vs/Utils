using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entidades;
using Data.DataContext;
using System.IO;
using System.Data.Entity;
using System.Security.AccessControl;

namespace Aprendizado.Controllers
{
    public class GerenciadorController : Controller
    {
        private DataContext _dataContext;

        /// <summary>
        /// Método Construtor instanciado um novo DataContext.
        /// </summary>
        public GerenciadorController()
        {
            _dataContext = new DataContext();
        }

        //
        // GET: /Diretorio/

        /// <summary>
        /// Método responsável por retornar a View Index.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Método responsável por listar todos os diretórios para a View Diretorio
        /// </summary>
        /// <returns></returns>
        public ActionResult Diretorio()
        {
            List<Diretorio> model = _dataContext.Diretorios.ToList();

            return View(model);
        }



        public ActionResult SalvarImagem(int? diretorioId)
        {
            TempData.Add("DiretorioID", diretorioId);
            TempData.Keep();
            //var diretorios = _dataContext.Diretorios.ToList();
            if (diretorioId == int.MinValue)
            {
                return RedirectToAction("Diretorio");
            }

            //var imagens = _dataContext.Imagens.Where(x => x.DiretorioId == diretorio.DiretorioId).Where(x => x.IsExcluido == false).ToList();

            return View();
        }
        /// <summary>
        /// Método responsável por 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SalvarImagem(List<HttpPostedFileBase> files)
        {
            int diretorioId = (int)TempData["DiretorioID"];
            TempData.Keep();
            var diretorio = _dataContext.Diretorios.Where(x => x.DiretorioId == diretorioId).ToList().First();
            if (diretorio == null)
            {
                return RedirectToAction("Diretorio");
            }

            int ultimoNumero = 0;
            Imagem imagem = _dataContext.Imagens.ToList().FindAll(x => x.DiretorioId == diretorio.DiretorioId).LastOrDefault();
            List<Imagem> imagens = new List<Imagem>();
            
            if (imagem != null)
            {
                ultimoNumero = Convert.ToInt32(imagem.Nome.Substring(3, 4));

                foreach (var item in files)
                {
                    ultimoNumero++;
                    string extension = Path.GetExtension(item.FileName);
                    string nome = "img" + RetornaNumeracao(ultimoNumero);
                    imagens.Add(new Imagem { Nome = nome, DiretorioId = diretorio.DiretorioId, IsExcluido = false, Extensao = extension });
                    string path = Path.Combine(Server.MapPath("~/Content/Imagens/" + diretorio.Nome + "/" + nome + extension));
                    item.SaveAs(path);
                }
            }
            else
            {
                foreach (var item in files)
                {
                    ultimoNumero++;
                    string extension = Path.GetExtension(item.FileName);
                    string nome = "img" + RetornaNumeracao(ultimoNumero);
                    imagens.Add(new Imagem { Nome = nome, DiretorioId = diretorio.DiretorioId, IsExcluido = false });
                    string path = Path.Combine(Server.MapPath("~/Content/Imagens/" + diretorio.Nome + "/" + nome + extension));
                    item.SaveAs(path);
                }
            }
            _dataContext.Imagens.AddRange(imagens);
            _dataContext.SaveChanges();

            return RedirectToAction("EditarDiretorio", diretorio.DiretorioId);
        }

        /// <summary>
        /// Método responsável por retornar a View AdicionarDiretorio
        /// </summary>
        /// <returns>View AdicionarDiretorio.</returns>
        public ActionResult AdicionarDiretorio()
        {

            return View();
        }

        /// <summary>
        /// Método resonsável por adicionar um novo diretorio e redirecionar para EditarDiretorio.
        /// </summary>
        /// <param name="model">model do Diretorio que vai ser inserido.</param>
        /// <returns>retorna EditarDiretorio se for insediro com sucesso, se não a AdicionarDiretorio e retornada.</returns>
        [HttpPost]
        public ActionResult AdicionarDiretorio(Diretorio model)
        {
            if (model != null)
            {
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Imagens/" + model.Nome));
                if (!di.Exists)
                {
                   
                    di.Create();                    
                }

                model.DataCriacao = DateTime.Now;
                model.DataUltimaAlteracao = DateTime.Now;
                model.IsExcluido = false;

                _dataContext.Diretorios.Add(model);
                _dataContext.SaveChanges();

                Diretorio d = _dataContext.Diretorios.Where(x => x.Nome == model.Nome).ToList().First();
                return RedirectToAction("EditarDiretorio", d);
            }

            return View();
        }

        /// <summary>
        /// Método responsável por exibir a página EditarDiretorio
        /// </summary>
        /// <param name="diretorioId">recebe o Id do diretorio que vai ser editado.</param>
        /// <returns>retorna a View EditarDiretorio.</returns>
        public ActionResult EditarDiretorio(int? diretorioId)
        {
            diretorioId = 2;
            if (diretorioId == null)
            {
                return RedirectToAction("Diretorio");
            }
            ViewData["Imagens"] = _dataContext.Imagens.ToList().FindAll(x => x.DiretorioId == diretorioId);
            ViewData["Diretorio"] = _dataContext.Diretorios.ToList().Find(x => x.DiretorioId == diretorioId);          

            return View();
        }

        /// <summary>
        /// Método post, representando a página EditarDiretorio para inserir, ou alterar imagens
        /// </summary>
        /// <param name="idImagens">id das imagens que vão ser alteradas.</param>
        /// <param name="files">são as novas imagens recebidas.</param>
        /// <param name="idDiretorio"> Diretorio que devem sofrer as alterações.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditarDiretorio(List<int> idImagens, List<HttpPostedFileBase> files, int? idDiretorio, string renameDiretorio)
        {

            var diretorio = _dataContext.Diretorios.Find(idDiretorio);
           
            if (diretorio == null)
            {
                return RedirectToAction("Diretorio");
            }           

            if (files[0] != null)
            {
                Imagem ultimaImagemInserida = _dataContext.Imagens.ToList().FindAll(x => x.DiretorioId == diretorio.DiretorioId).LastOrDefault();

                SalvarImagens(ultimaImagemInserida, files, diretorio);   
            }

            if (idImagens != null)
            {
                List<Imagem> listaImagens = new List<Imagem>();
                for (var i = 0; i < idImagens.Count;i++ )
                {
                    listaImagens.Add(_dataContext.Imagens.ToList().Find(x => x.ImagemId == idImagens[i]));
                    listaImagens[i].IsExcluido = true;
                }
                _dataContext.Entry(listaImagens).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }

            if (diretorio.Nome != renameDiretorio)
            {
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Imagens/" + diretorio.Nome));
                di.MoveTo(renameDiretorio);
                diretorio.Nome = renameDiretorio;

                _dataContext.Entry(diretorio).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
                     

            return RedirectToAction("EditarDiretorio", diretorio.DiretorioId);
        }


        /// <summary>
        /// Método responsável por retornar a numeração correta das imagens para cada diretório.
        /// </summary>
        /// <param name="n">é o número retornado da última imagem ou a primeira a ser inserida.</param>
        /// <returns>a númeração que deve ser inserida.</returns>
        private string RetornaNumeracao(int n) 
        {
            string numero = n.ToString();
            if (numero.Count() == 1)
            {
                return numero.Replace(numero, "000" + numero);
            }
            else if (numero.Count() == 2)
            {
                return numero.Replace(numero, "00" + numero);
            }else if(numero.Count() == 3)
            {
                return numero.Replace(numero, "0" + numero);
            }
            else
            {
                return numero;
            }

        }

        /// <summary>
        /// Método responsável por salvar as imagens no diretório correto.
        /// </summary>
        /// <param name="ultimaImagemInsedira">model da última imagem inserida</param>
        /// <param name="files">Arquivos recebidos</param>
        /// <param name="diretorio">Diretorio que os arquivos recebidos devem ser gravados.</param>
        private void SalvarImagens(Imagem ultimaImagemInsedira, List<HttpPostedFileBase> files, Diretorio diretorio)
        {
            int ultimoNumero = 0;
            List<Imagem> imagens = new List<Imagem>();

            if (ultimaImagemInsedira != null)
            {
                ultimoNumero = Convert.ToInt32(ultimaImagemInsedira.Nome.Substring(3, 4));

                foreach (var item in files)
                {
                    ultimoNumero++;
                    string extension = Path.GetExtension(item.FileName);
                    string nome = "img" + RetornaNumeracao(ultimoNumero);
                    imagens.Add(new Imagem { Nome = nome, DiretorioId = diretorio.DiretorioId, IsExcluido = false, Extensao = extension });
                    string path = Path.Combine(Server.MapPath("~/Content/Imagens/" + diretorio.Nome + "/" + nome + extension));
                    item.SaveAs(path);
                }
            }
            else
            {
                foreach (var item in files)
                {
                    ultimoNumero++;
                    string extension = Path.GetExtension(item.FileName);
                    string nome = "img" + RetornaNumeracao(ultimoNumero);
                    imagens.Add(new Imagem { Nome = nome, DiretorioId = diretorio.DiretorioId, IsExcluido = false });
                    string path = Path.Combine(Server.MapPath("~/Content/Imagens/" + diretorio.Nome + "/" + nome + extension));
                    item.SaveAs(path);
                }
            }
            _dataContext.Imagens.AddRange(imagens);
            _dataContext.SaveChanges();
            
        }
    }
}
