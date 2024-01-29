using System.Diagnostics;

namespace AsyncTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YumurtaYap().Wait();

            async Task YumurtaYap()
            {
                var sw = Stopwatch.StartNew();

                #region [ sync calls ]

                // syncron methods with only one thread.

                //YumurtaKir(); 
                //YumurtaCirp();
                //TuzEkle();
                //OcagiAc();
                //TavayiIsit();
                //YagiDok();
                //YumurtayiEkle();
                //Pisir();
                //ServisEt();

                #endregion

                #region [ async calls ]

                // asyncron methods.

                //YumurtaKirAsync();
                //YumurtaCirpAsync();
                //TuzEkleAsync();
                //OcagiAcAsync();
                //TavayiIsitAsync();
                //YagiDokAsync();
                //YumurtayiEkleAsync();
                //PisirAsync();
                //ServisEtAsync();

                #endregion

                #region [ Grouped Tasks ]

                var yumurtaHazirlikGroup = YumurtaKirAsync().ContinueWith(async _ => {
                    await YumurtaCirpAsync();
                    await TuzEkleAsync();
                });

                var ocakTaskGroup = OcagiAcAsync().ContinueWith(async _ => {
                    await TavayiIsitAsync();
                    await YagiDokAsync();
                });

                await Task.WhenAll(yumurtaHazirlikGroup, ocakTaskGroup);

                await Console.Out.WriteLineAsync(" ****** Yumurta ve ocak hazır ***********");

                await YumurtayiEkleAsync();
                await PisirAsync();
                await ServisEtAsync();

                #endregion

                Console.WriteLine("Yumurtların totalde hazır edilme süresi {0}", sw.ElapsedMilliseconds);

            }

            #region [ Functions ]

            #region [sync methods]

            void YumurtaKir()
            {
                Task.Delay(4000).Wait(); 
                // if we wait for 10 seconds, in this time era the ui will not be able to controlled. Everything will be locked until it finishes.

                Console.WriteLine("Yumurtalar kirildi");
            }

            void YumurtaCirp()
            {
                Task.Delay(2000).Wait();
                Console.WriteLine("Yumurtalar çırpıldı");
            }

            void TuzEkle()
            {
                Task.Delay(100).Wait();
                Console.WriteLine("Tuz eklendi");
            }

            void OcagiAc()
            {
                Task.Delay(200).Wait();
                Console.WriteLine("Ocağın altı açıldı");
            }

            void TavayiIsit()
            {
                Task.Delay(4000).Wait();
                Console.WriteLine("Tavanın altı ısıtıldı");
            }

            void YagiDok()
            {
                Task.Delay(300).Wait();
                Console.WriteLine("Yağ döküldü");
            }

            void YumurtayiEkle()
            {
                Task.Delay(100).Wait();
                Console.WriteLine("Yumurtalar eklendi");
            }

            void Pisir()
            {
                Task.Delay(5000).Wait();
                Console.WriteLine("Yumurtalar pişirildi");
            }

            void ServisEt()
            {
                Task.Delay(10).Wait();
                Console.WriteLine("Servis edildi");
            }

            #endregion

            #region [ async methods ]

            async Task YumurtaKirAsync() // if the method is an event, return can be void. Else make sure that it returns back a Task object.
            {
                Console.WriteLine("Yumurtalar kırılmaya başlanıyor. 1");

                await Task.Delay(4000);

                Console.WriteLine("Yumurtalar kirildi 1");

            }

            async Task YumurtaCirpAsync()
            {
                Console.WriteLine("Yumurtalar çırpılmaya başlandı 2");
                Task.Delay(2000).Wait();
                Console.WriteLine("Yumurtalar çırpıldı 2");
            }

            async Task TuzEkleAsync()
            {
                Console.WriteLine("Tuz ekleniyor 3");
                Task.Delay(1000).Wait();
                Console.WriteLine("Tuz eklendi 3");
            }

            async Task OcagiAcAsync()
            {
                Console.WriteLine("Ocağın altı açılıyor 4");
                Task.Delay(2000).Wait();
                Console.WriteLine("Ocağın altı açıldı 4");
            }

            async Task TavayiIsitAsync()
            {
                Console.WriteLine("Tavanın altı ısıtılıyor 5");
                Task.Delay(6000).Wait();
                Console.WriteLine("Tavanın altı ısıtıldı 5");
            }

            async Task YagiDokAsync()
            {
                Console.WriteLine("Yağ dökülüyor 6");
                Task.Delay(1000).Wait();
                Console.WriteLine("Yağ döküldü 6");
            }

            async Task YumurtayiEkleAsync()
            {
                Console.WriteLine("Yumurtalar ekleniyor 7");
                Task.Delay(2000).Wait();
                Console.WriteLine("Yumurtalar eklendi 7");
            }

            async Task PisirAsync()
            {
                Console.WriteLine("Yumurtalar pişiriliyor 8");
                Task.Delay(3000).Wait();
                Console.WriteLine("Yumurtalar pişirildi 8");
            }

            async Task ServisEtAsync()
            {
                Console.WriteLine("Servis ediliyor 9");
                Task.Delay(1000).Wait();
                Console.WriteLine("Servis edildi 9");
            }

            #endregion

            #endregion
        }
    }
}
