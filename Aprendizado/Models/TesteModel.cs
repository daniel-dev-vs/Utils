using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Aprendizado.Models
{

    //public class TestContext : DbContext
    //{
    //    public TestContext()
    //        : base("Conexao")
    //    {
    //    }

    //    public DbSet<TesteModel> TesteModels { get; set; }
    //}


   [Serializable]
    [XmlRoot("TesteModels"), XmlType("TesteModels")]
    public class TesteModel
    {
        
       public int TesteId { get; set; }

       public string Nome { get; set; }

       public string SobreNome { get; set; }
       public HttpPostedFileBase arquivo;
    }

    public class TesteRegisterModel 
    {
        [Required]
        [Display(Name = "Seu nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Seu sobrenome")]
        public string Sobrenome { get; set; }
        
    }

    public class XmlReader
    {
        /// <summary>  
        /// Return list of products from XML.  
        /// </summary>  
        /// <returns>List of products</returns>  
        public List<TesteModel> RetrunListOfTestes()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/Teste.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var testes = new List<TesteModel>();
            testes = (from rows in ds.Tables[0].AsEnumerable()
                        select new TesteModel
                        {
                            TesteId = Convert.ToInt32(rows[0].ToString()), //Convert row to int  
                            Nome = rows[1].ToString(),
                            SobreNome = rows[2].ToString(),
                        }).ToList();
            return testes;
        }   

    }
}