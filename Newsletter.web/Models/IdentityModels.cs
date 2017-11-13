using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using DatabaseLayer;

namespace Newsletter.web.Models
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext() {}

        public static BaseContext Create()
        {
            return new BaseContext();
        }
    }
}