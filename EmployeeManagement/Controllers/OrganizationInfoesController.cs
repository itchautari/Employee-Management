using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;
using System.IO;
using EmployeeManagement.Helpers;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/OrganizationInfoes")]
    public class OrganizationInfoesController : Controller
    {
        private readonly EmployeemanagementContext db;
        private readonly IHostingEnvironment hostingEnvironment;

        public OrganizationInfoesController(EmployeemanagementContext context, IHostingEnvironment _hostingEnvironment)
        {
            db = context;
            hostingEnvironment = _hostingEnvironment;
        }

        // GET: api/OrganizationInfoes
        [HttpGet]
        public IEnumerable<OrganizationInfo> GetOrganizationInfo()
        {
            return db.OrganizationInfo;
        }

        //// GET: api/OrganizationInfoes
        //[HttpGet]
        //public IActionResult GetOrganizationInfo()
        //{
        //    var organizations = db.OrganizationInfo.Select(oi => new {
        //        oi.OrganizationNameEn,
        //        oi.PanNo,
        //        oi.AddressEn,
        //        oi.Email,
        //        oi.Website,
        //        oi.Logo,
        //        oi.EstablishedDateEn,
        //        oi.CreateDateEn,
        //        oi.ModifiedDate,
        //        oi.ModifiedBy
        //    }).ToList();
        //    return Ok(organizations);
        //}

        // GET: api/OrganizationInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationInfo = await db.OrganizationInfo.SingleOrDefaultAsync(m => m.OrganizationId == id);

            //var organizationInfo = await db.OrganizationInfo.Select(o => new{
            //    o.OrganizationId,
            //    o.OrganizationNameEn,
            //    o.OrganizationNameNp,
            //    o.PanNo,
            //    o.AddressEn,
            //    o.AddressNp,
            //    o.Email,
            //    o.EstablishedDateEn,
            //    o.EstablishedDateNp,
            //    o.Logo,
            //    o.Website
            //}).SingleOrDefaultAsync(m => m.OrganizationId == id);

            if (organizationInfo == null)
            {
                return NotFound();
            }

            return Ok(organizationInfo);
        }

        // PUT: api/OrganizationInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationInfo([FromRoute] int id )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IFormFileCollection files = Request.Form.Files;
            string filePath = "";
            if(files.Count > 0 && files[0] != null)
            {
                filePath = UploadFile(files[0], "Assets/Uploads/Images");
            }
            var frm = Request.Form;
            OrganizationInfo org = new OrganizationInfo() {
                OrganizationId = int.Parse(frm["organizationId"]),
                OrganizationNameEn = frm["organizationNameEn"] == "null" ? "" : frm["organizationNameEn"].ToString(),
                OrganizationNameNp = frm["organizationNameNp"] == "null" ? "" : frm["organizationNameNp"].ToString(),
                PanNo = frm["panNo"] == "null" ? "" : frm["panNo"].ToString(),
                Email = frm["email"] == "null" ? "" : frm["email"].ToString(),
                Logo = filePath,
                AddressEn = frm["addressEn"] == "null" ? "" : frm["addressEn"].ToString(),
                AddressNp = frm["addressNp"] == "null" ? "" : frm["addressNp"].ToString(),
                CreateDateEn = frm["createDateEn"],
                EstablishedDateEn = frm["establishedDateEn"],
                EstablishedDateNp = frm["establishedDateNp"],
                ModifiedBy = CurrentUser.userId.ToString(),
                ModifiedDate = DateTime.Now.ToString("yyyy/MM/dd"),
                Website = frm["website"]
            };

            db.Entry(org).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!OrganizationInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(org);

            //if (id != orgInfoWF.organizationInfo.OrganizationId)
            //{
            //    return BadRequest();
            //}

            //if (orgInfoWF.fileName != null && orgInfoWF.fileName != "")
            //{
            //    if (ImageHandler.Base64ToImage(orgInfoWF.logoImg, "Assets/Images", orgInfoWF.fileName))
            //    {
            //        orgInfoWF.organizationInfo.Logo = "Assets/Images/"+orgInfoWF.fileName.Replace('\\', '/');
            //    }
            //}
            //var organizationInfo = orgInfoWF.organizationInfo;
            //organizationInfo.ModifiedDate = DateTime.Now.ToString("yyyy/MM/dd");
            //organizationInfo.ModifiedBy = CurrentUser.userId.ToString();
            //organizationInfo.Logo = "Assets/Images/" + orgInfoWF.fileName.Replace('\\', '/');

            //db.Entry(organizationInfo).State = EntityState.Modified;

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    if (!OrganizationInfoExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return Ok(organizationInfo);

        }


        public string UploadFile(IFormFile file, string folderName)
        {
            string filePath = "";
            try
            {
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filePath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return filePath;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        // POST: api/OrganizationInfoes
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> PostOrganizationInfo()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if (orgInfoWF.fileName != null && orgInfoWF.fileName != "")
            //{
            //    if (ImageHandler.Base64ToImage(orgInfoWF.logoImg, "Assets/Images", orgInfoWF.fileName))
            //    {
            //        orgInfoWF.organizationInfo.Logo = Path.Combine("Assets/Images", orgInfoWF.fileName).Replace('\\', '/');
            //    }
            //}
            //var organizationInfo = orgInfoWF.organizationInfo;

            IFormFileCollection files = Request.Form.Files;
            string filePath = "";
            if (files.Count > 0 && files[0] != null)
            {
                filePath = UploadFile(files[0], "Assets/Uploads/Images");
            }
            var frm = Request.Form;
            OrganizationInfo organizationInfo = new OrganizationInfo()
            {
                OrganizationNameEn = frm["organizationNameEn"] == "null" ? "" : frm["organizationNameEn"].ToString(),
                OrganizationNameNp = frm["organizationNameNp"] == "null" ? "" : frm["organizationNameNp"].ToString(),
                PanNo = frm["panNo"] == "null" ? "" : frm["panNo"].ToString(),
                Email = frm["email"] == "null" ? "" : frm["email"].ToString(),
                Logo = filePath,
                AddressEn = frm["addressEn"] == "null" ? "" : frm["addressEn"].ToString(),
                AddressNp = frm["addressNp"] == "null" ? "" : frm["addressNp"].ToString(),
                CreateDateEn = frm["createDateEn"],
                EstablishedDateEn = frm["establishedDateEn"],
                EstablishedDateNp = frm["establishedDateNp"],
                Website = frm["website"]
            };

            organizationInfo.CreateDateEn = DateTime.Now.ToString("yyyy/MM/dd");
            db.OrganizationInfo.Add(organizationInfo);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }

            return CreatedAtAction("GetOrganizationInfo", new { id = organizationInfo.OrganizationId }, organizationInfo);
        }

        // DELETE: api/OrganizationInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizationInfo = await db.OrganizationInfo.SingleOrDefaultAsync(m => m.OrganizationId == id);
            if (organizationInfo == null)
            {
                return NotFound();
            }

            db.OrganizationInfo.Remove(organizationInfo);
            await db.SaveChangesAsync();

            return Ok(organizationInfo);
        }

        private bool OrganizationInfoExists(int id)
        {
            return db.OrganizationInfo.Any(e => e.OrganizationId == id);
        }

    }
}