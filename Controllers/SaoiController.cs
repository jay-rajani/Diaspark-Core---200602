using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Diaspark.Models;
using Diaspark.Manager;

namespace Diaspark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaoiController : ControllerBase
    {
        SaoiManager SalesManager = new SaoiManager();
        int li_ret = 0;

        //public SaoiController()
        //{
        //    saoiManager = new SaoiManager();
        //}
        
        //https://localhost:44372/api/SaoiInvoice/
        [HttpGet]
        public IQueryable<saoitrinvhd> GetAllInvoices()
        {

            return SalesManager.GetAllInvoices();
        }

        //https://localhost:44372/api/SaoiInvoice/SI01?trans_no=30N3&trans_bk=SI01
        [HttpGet("{id}")]
        public ActionResult<saoitrinvhd> GetInvoice(string trans_no, string trans_bk)
        {

            string dtl_type = "Y";
            saoitrinvhd data = SalesManager.GetInvoice(trans_no, trans_bk, dtl_type);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        //https://localhost:44372/api/Saoi
        [HttpPost]
        public IActionResult Create(saoitrinvhd data)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            li_ret = SalesManager.Create(data);

            if (li_ret == 500)
            {
                return Conflict();
                //return BadRequest();
            }

            else
            {
                return Ok(data);
            }
        }

        //https://localhost:44372/api/Saoi?trans_no=30N3&trans_bk=SI01&company_id=DS02
        [HttpPut]
        public IActionResult Update(string trans_no, string trans_bk, string company_id, saoitrinvhd data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            li_ret = SalesManager.Update(trans_no, trans_bk, company_id, data);


            if (li_ret == 500)
            {

                return BadRequest();
            }

            else
            {
                return NoContent();
            }
        }

    }
}