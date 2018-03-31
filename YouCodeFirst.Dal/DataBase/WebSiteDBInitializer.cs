using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Dal.Models;
using WebSite.Dal.Models.Account;

using WebSite;
using Microsoft.AspNet.Identity;

namespace WebSite.Dal.DataBase
{
    class WebSiteDBInitializer: DropCreateDatabaseIfModelChanges<WebSiteDBContext>
    {
        protected override void Seed(WebSiteDBContext context)
        {
            Random rand = new Random();
            string[] noms = { "Martin", "Bernard", "Thomas", "Petit", "Robert", "Richard", "Durand" };
            string[] adresses = { "chemin de la justice", "rue bernard lepecq", "rue des vallés", "chemin de la pavillon", "route de la malnoue", "route des champs", "rue des jules vernes" };
            string[] prenoms = { "Abel", "Pascale", "Paul", "Adelaide", "Adele", "Adeline", "Noemie" };
            string[] Villes = { "Paris", "Laval", "Lemans", "Rennes", "Besançon", "Nantes", "Nice" };
            string[] Pays = { "France", "Tunisie", "Belgique", "USA", "Inde", "Canada", "Argentine" };

            Key key_1 = new Key()
            {
                Name = "Nom",
            };

            Key key_2 = new Key()
            {
                Name = "Adresse"
            };

            Key key_3 = new Key()
            {
                Name = "Prénom"
            };

            Key key_4 = new Key()
            {
                Name = "Facture"
            };

            Key key_5 = new Key()
            {
                Name = "Code client"
            };

            Key key_6 = new Key()
            {
                Name = "Ville"
            };

            Key key_7 = new Key()
            {
                Name = "Code postal"
            };

            Key key_8 = new Key() { Name = "Nbre Vote" };

            Key key_9 = new Key() { Name = "Réference" };

            Key key_10 = new Key() { Name = "Pays" };

            ListAttribute ls1 = new ListAttribute
            {
                Visiblity = true,
                Name = "liste 1"
            };
            ls1.Keys.Add(key_1);
            ls1.Keys.Add(key_2);
            ls1.Keys.Add(key_3);
            ls1.Keys.Add(key_4);
            ls1.Keys.Add(key_5);

            ListAttribute ls2 = new ListAttribute
            {
                Visiblity = true,
                Name = "liste 2"
            };
            ls2.Keys.Add(key_5);
            ls2.Keys.Add(key_7);
            ls2.Keys.Add(key_8);
            ls2.Keys.Add(key_9);
            ls2.Keys.Add(key_10);

            ListAttribute ls3 = new ListAttribute
            {
                Visiblity = true,
                Name = "liste 3"
            };
            ls3.Keys.Add(key_1);
            ls3.Keys.Add(key_3);
            ls3.Keys.Add(key_2);
            ls3.Keys.Add(key_9);
            ls3.Keys.Add(key_10);

            OperationType OpType_1 = new OperationType
            {
                name = OpType.Ag,
                ListAttribute = ls1
            };

            OperationType OpType_2 = new OperationType
            {
                name = OpType.Vote,
                ListAttribute = ls2
            };

            OperationType OpType_3 = new OperationType
            {
                name = OpType.Pda,
                ListAttribute = ls3
            };


            /************ Operation 1 *****************/


            Operation op1 = new Operation
            {
                Begin = DateTime.Now,
                End = DateTime.Now.AddDays(30),
                Name = "Operation 1",
                Type = OpType_1
            };


            // 5000 docuements pour la 1er operation
            for (int i = 0; i < 300; i++)
            {
                Document d = new Document
                {
                    creationDate = DateTime.Now,
                    operation = op1
                };

                Dal.Models.Attribute at1 = new Dal.Models.Attribute
                {
                    Key = key_1,
                    Value = noms[rand.Next(0, 7)]
                };


                Dal.Models.Attribute at2 = new Dal.Models.Attribute
                {
                    Key = key_2,
                    Value = rand.Next(0, 100) + " " + adresses[rand.Next(0, 7)]
                };

                Dal.Models.Attribute at3 = new Dal.Models.Attribute
                {
                    Key = key_3,
                    Value = prenoms[rand.Next(0, 7)]
                };

                Dal.Models.Attribute at4 = new Dal.Models.Attribute
                {
                    Key = key_4,
                    Value = rand.Next(1000, 10000).ToString()
                };

                Dal.Models.Attribute at5 = new Dal.Models.Attribute
                {
                    Key = key_5,
                    Value = "00-" + rand.Next(2000, 3000)
                };


                d.Attributes.Add(at1);
                d.Attributes.Add(at2);
                d.Attributes.Add(at3);
                d.Attributes.Add(at4);
                d.Attributes.Add(at5);

                d.scanFile = new ScanFile()
                {
                    Name = "StandardFile-" + i + ".pdf",
                };

                context.Documents.Add(d);
                context.SaveChanges();
            }


            /************ Operation 2 *****************/


            Operation op2 = new Operation
            {
                Begin = DateTime.Now,
                End = DateTime.Now.AddDays(60),
                Name = "Operation 2",
                Type = OpType_2
            };

            // 100 docuements pour la 2eme operation
            for (int i = 300; i < 600; i++)
            {
                Document d = new Document
                {
                    creationDate = DateTime.Now,
                    operation = op2
                };

                Dal.Models.Attribute at5 = new Dal.Models.Attribute
                {
                    Key = key_5,
                    Value = "00-" + rand.Next(3000, 4000)
                };

                Dal.Models.Attribute at7 = new Dal.Models.Attribute
                {
                    Key = key_7,
                    Value = rand.Next(75000, 100000).ToString()
                };

                Dal.Models.Attribute at8 = new Dal.Models.Attribute
                {
                    Key = key_8,
                    Value = rand.Next(7, 100).ToString()
                };

                Dal.Models.Attribute at9 = new Dal.Models.Attribute
                {
                    Key = key_9,
                    Value = rand.Next(10000, 100000).ToString() //ref
                };

                Dal.Models.Attribute at10 = new Dal.Models.Attribute
                {
                    Key = key_10,
                    Value = Pays[rand.Next(0, 7)] // pays
                };

                d.Attributes.Add(at5);
                d.Attributes.Add(at7);
                d.Attributes.Add(at8);
                d.Attributes.Add(at9);
                d.Attributes.Add(at10);

                d.scanFile = new ScanFile()
                {
                    Name = "StandardFile-" + i + ".pdf",
                };

                context.Documents.Add(d);
                context.SaveChanges();
            }

            /************ Operation 3 *****************/


            Operation op3 = new Operation
            {
                Begin = DateTime.Now,
                End = DateTime.Now.AddDays(45),
                Name = "Operation 3",
                Type = OpType_3
            };


            // 100 docuements pour la 3eme operation
            for (int i = 600; i < 900; i++)
            {
                Document d = new Document
                {
                    creationDate = DateTime.Now,
                    operation = op3
                };

                Dal.Models.Attribute at1 = new Dal.Models.Attribute
                {
                    Key = key_1,
                    Value = noms[rand.Next(0, 7)]
                };

                Dal.Models.Attribute at3 = new Dal.Models.Attribute
                {
                    Key = key_3,
                    Value = prenoms[rand.Next(0, 7)]
                };

                Dal.Models.Attribute at2 = new Dal.Models.Attribute
                {
                    Key = key_2,
                    Value = rand.Next(0, 100) + " " + adresses[rand.Next(0, 7)]
                };

                Dal.Models.Attribute at9 = new Dal.Models.Attribute
                {
                    Key = key_9,
                    Value = rand.Next(10000, 100000).ToString()
                };

                Dal.Models.Attribute at10 = new Dal.Models.Attribute
                {
                    Key = key_10,
                    Value = Pays[rand.Next(0, 7)]
                };

                d.Attributes.Add(at1);
                d.Attributes.Add(at3);
                d.Attributes.Add(at2);
                d.Attributes.Add(at9);
                d.Attributes.Add(at10);

                d.scanFile = new ScanFile()
                {
                    Name = "StandardFile-" + i + ".pdf",
                };

                context.Documents.Add(d);
                context.SaveChanges();
            }

            //********************************

            Application app = new Application() { Name = "Application A" };
            app.Operations.Add(op1);
            app.Operations.Add(op2);
            app.Operations.Add(op3);

            //********************************

            
        }
    }
}
