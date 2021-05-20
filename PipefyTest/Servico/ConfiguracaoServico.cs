using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace PipefyTest
{
    public class ConfiguracaoServico
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                //configura o serviço para chamar os seus metodos de start e stop
                //também é possível fazer por exemplo 'service.WhenShutDown'
                configure.Service<MeuServicoWS>(service =>
                {
                    service.ConstructUsing(s => new MeuServicoWS());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                //configura a conta que o servico do windows usa para executar
                configure.RunAsLocalSystem();
                configure.SetServiceName("Nome do meu primeiro serviço");
                configure.SetDisplayName("Display name do meu serviço");
                configure.SetDescription("Descrição do meu serviço");
            });

        }
    }
}
