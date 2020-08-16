using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Appempresas.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : Controller
    {
       
        [HttpGet]
        //[Authorize]
        public ActionResult Get()
        {
            using (var excelPackage = new ExcelPackage())
            {
                //Cria um workspace
                var worksheet = excelPackage.Workbook.Worksheets.Add("Novo Planilha");

                //Cria o Header de cada coluna...
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Value = "Nome";
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Value = "CPF";
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Value = "Telefone";

                //Cria cada linha em suas respectivasc colunas
                for (var linha = 2; linha <= 101; linha++)
                {
                    var faker = new Faker("pt_BR");
                    var cpf = faker.Person.Cpf().Replace(".", "").Replace("-", "").Trim();
                    var name = faker.Person.FullName;
                    var phone = faker.Person.Phone;

                    worksheet.Cells[linha, 1].Value = name;
                    worksheet.Cells[linha, 2].Value = cpf;
                    worksheet.Cells[linha, 3].Value = phone;
                }

                return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "teste.xls");
            }
        }
    }
}