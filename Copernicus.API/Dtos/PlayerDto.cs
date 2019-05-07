using System;

namespace Copernicus.API.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public long WinGames { get; set; }
        public long TotalGames { get; set; }
        public long Score { get; set; }
    }
}
