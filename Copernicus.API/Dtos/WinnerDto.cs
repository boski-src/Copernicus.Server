using System;

namespace Copernicus.API.Dtos
{
    public class WinnerDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
    }
}