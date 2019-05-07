using System;

namespace Copernicus.API.Dtos
{
    public class MemberDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserAvatarUrl { get; set; }
        public bool IsCreator { get; set; }
    }
}
