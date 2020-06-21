using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    class Program
    {

        /*
                
                 interfacenin doğru planması gerektiğini söyleyen S O L I D 'in "I" harfini yaptık. 
     Yazılım geliştirmenin 5 temel prensibi vardır S O L I D
                 S — Single-responsibility principle
           ÖZET: Bir sınıf (nesne) yalnızca bir amaç uğruna değiştirilebilir, o da o sınıfa yüklenen sorumluluktur, yani bir sınıfın(fonksiyona da indirgenebilir) yapması gereken yalnızca bir işi olması gerekir.
                 O — Open-closed principle
           ÖZET: Bir sınıf ya da fonksiyon halihazırda var olan özellikleri korumalı ve değişikliğe izin vermemelidir. Yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabiliyor olmalıdır.
                  L — Liskov substitution principle
           ÖZET: Kodlarımızda herhangi bir değişiklik yapmaya gerek duymadan alt sınıfları, türedikleri(üst) sınıfların yerine kullanabilmeliyiz.
                  I — Interface segregation principle
           ÖZET: Sorumlulukların hepsini tek bir arayüze toplamak yerine daha özelleştirilmiş birden fazla arayüz oluşturmalıyız.
                  D — Dependency Inversion Principle
           ÖZET: Sınıflar arası bağımlılıklar olabildiğince az olmalıdır özellikle üst seviye sınıflar alt seviye sınıflara bağımlı olmamalıdır.
        
         */
        static void Main(string[] args)
        {


            IWorker[] workers = new IWorker[3]
            {
                new Worker(),
                new Manager(),
                new Robot()
            };
            foreach (var worker in workers)
            {
                worker.Work();
            }

            IEat[] eats = new IEat[2]
            {
                //burada robot gelmez çünkü biz robotu tanımlamadık!!!
                new Manager(),
                new Worker()
            };
            foreach (var eat in eats)
            {
                eat.Eat();
            }




        }
        // Manager, Worker, Robot
        interface IWorker
        {
            void Work();
        }

        interface IEat
        {
            void Eat();
        }
        interface ISalary
        {
            void GetSalary();
        }


        class Manager : IWorker, IEat, ISalary
        {
            public void Work()
            {
                throw new NotImplementedException();
            }

            public void Eat()
            {
                throw new NotImplementedException();
            }

            public void GetSalary()
            {
                throw new NotImplementedException();
            }
        }



        class Worker : IWorker, IEat, ISalary
        {
            public void Work()
            {
                throw new NotImplementedException();
            }

            public void Eat()
            {
                throw new NotImplementedException();
            }

            public void GetSalary()
            {
                throw new NotImplementedException();
            }
        }
        /*robot yemek yemez!!! maaş almaz!!! yani interface'ler amaçlarına uygun tasarlanmamıştır
        deriz bu yüzden interfaceleri ayırmamız gerekebilir.*/
        class Robot : IWorker
        {
            public void Work()
            {
                throw new NotImplementedException();
            }
        }
    }
}
