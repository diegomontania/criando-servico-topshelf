using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipefyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //chamando configuração do serviço que irá de fato chamar a classe que o inicia
            ConfiguracaoServico.Configure();
        }
    }
}
