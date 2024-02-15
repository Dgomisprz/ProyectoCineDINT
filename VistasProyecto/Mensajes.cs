using CommunityToolkit.Mvvm.Messaging.Messages;
using ProyectoCine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCine
{
    class SalaSendMessage : ValueChangedMessage<Salas>
    {
        public SalaSendMessage(Salas s): base(s) { }
    }
    class SalaRecieveMessage: RequestMessage<Salas> { }
    class SesionSendMessage : ValueChangedMessage<Sesiones>
    {
        public SesionSendMessage(Sesiones s): base(s) { }
    }
    class SesionRecieveMessage:RequestMessage<Sesiones> { }
}
