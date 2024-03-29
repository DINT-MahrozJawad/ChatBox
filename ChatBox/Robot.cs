﻿using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatBox
{
    class Robot
    {
        QnAMakerRuntimeClient cliente;
        string id;
        bool conectado;

        public Robot()
        {
            string EndPoint = "https://botmahroz.azurewebsites.net";
            string Key = "a5e51ac1-8679-407f-9f42-1d70dadfd230";
            Id = "ba514545-ce8f-4d28-8c96-0e30f9aa6f29";
            cliente = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(Key)) { RuntimeEndpoint = EndPoint };
        }

        public string Id { get => id; set => id = value; }
        public bool Conectado { get => conectado; set => conectado = value; }

        public async Task<string> RespuestaRobotAsync(string pregunta)
        {
            QnASearchResultList response = await cliente.Runtime.GenerateAnswerAsync(Id, new QueryDTO { Question = pregunta });
            string respuesta = response.Answers[0].Answer;
            return respuesta;
        }

        public async void ComprobarConexionAsync()
        {
            try
            {
                await RespuestaRobotAsync("Hola");
                Conectado = true;
            }
            catch (Exception)
            {
                Conectado = false;
            }
            finally
            {
                if (Conectado)
                    MessageBox.Show("El Robot esta conectado", "ChatBox", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("No se ha podido conectar con el robot", "ChatBox", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

    }
}
