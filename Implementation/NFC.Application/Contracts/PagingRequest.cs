namespace NFC.Application.Contracts
{
    public class PagingRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool GetLastest { get; set; }
    }
}
