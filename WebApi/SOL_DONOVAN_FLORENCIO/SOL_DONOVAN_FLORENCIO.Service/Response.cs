namespace SOL_DONOVAN_FLORENCIO.Service
{
    public class Response<T>
    {
        public T? Entity;
        public int Status;
        public bool Exito;
        public string? Error;

        public Response()
        {
            Status = 200;
        }
        public void BadRequest(string error)
        {
            Status = 400;
            Error = error;
            Exito = false;
        }

        public void InternalServerError(string error)
        {
            Status = 500;
            Error = error;
            Exito = false;
        }

        public void ReglaNegocioError(string error)
        {
            Status = 200;
            Error = error;
            Exito = false;
        }

    }
}
