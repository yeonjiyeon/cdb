using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Context
{
    public class fData:DbContext
    {
        public fData() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KOSTA\source\repos\MyTable.mdf;Integrated Security=True;Connect Timeout=30") 
        { }
        //디비데이터들을 list형태로 가져온다
        //facility list, 정의를 하는 것
        public DbSet<facility> Facilities { get; set; } 
        //get과 set을 속성을 만들다 facility모델데이터리스트를 Facilities로 호출할 수 있다
    }
}