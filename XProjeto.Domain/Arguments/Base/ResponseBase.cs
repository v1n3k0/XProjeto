using System;
using XProjeto.Domain.Entities;

namespace XProjeto.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = XProjeto.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
        public string Message { get; set; }

        public static explicit operator ResponseBase(Entities.Jogo v)
        {
            return new ResponseBase()
            {
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
