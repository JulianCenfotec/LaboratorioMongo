using LaboratorioMongo.Modelos;
using LaboratorioMongo.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboratorioMongo
{
    
        public class Observador : IObservable<string>
        {
            private List<IObserver<string>> observadores = new List<IObserver<string>>();

            public IDisposable Subscribe(IObserver<string> observer)
            {
                if (!observadores.Contains(observer))
                {
                    observadores.Add(observer);
                }
                return new Unsubscriber(observadores, observer);
            }

            public void NotificarObservadores(string mensaje)
            {
                foreach (var observador in observadores)
                {
                    observador.OnNext(mensaje);
                }
            }

            private class Unsubscriber : IDisposable
            {
                private readonly List<IObserver<string>> _observadores;
                private readonly IObserver<string> _observer;

                public Unsubscriber(List<IObserver<string>> observadores, IObserver<string> observer)
                {
                    _observadores = observadores;
                    _observer = observer;
                }

                public void Dispose()
                {
                    if (_observadores.Contains(_observer))
                    {
                        _observadores.Remove(_observer);
                    }
                }
            }
        }

    }



