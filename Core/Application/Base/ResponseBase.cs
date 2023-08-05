using Newtonsoft.Json;

namespace Application.Base
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            IDCodigo = 0;
            Message = "¡Operación exitosa!";
        }
        public int IDCodigo { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}