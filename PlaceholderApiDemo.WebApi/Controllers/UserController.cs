using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FrameWork;
using Microsoft.AspNetCore.Mvc;
using PlaceholderApiDemo.Library;
using PlaceholderApiDemo.Library.Models;
using PlaceholderApiDemo.Library.Repositories.Abstract;

namespace PlaceholderApiDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController<User> {
        IAlbumRepository albumRepository;
        IUserRepository userRepository => (IUserRepository)repository;
        public UserController(ILogService _logService, 
                              IUserRepository userRepository,
                              IAlbumRepository _albumRepository)
            : base(_logService, userRepository) {
            albumRepository = _albumRepository;
        }

        [HttpGet("/api/[controller]/{id}/albums")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumListByUserId(int id){
            try {
                var res = await albumRepository.GetAlbumsByUserId(id);
                return res;
            }
            catch(Exception e) {
                logService.LogFatal(e);
#if DEBUG
                throw e;
#endif
            }
            return null;
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<User>>> Get() {
            try {
                var res = await userRepository.GetAllAsync();
                res.ForEach(u => u.Email = EncryptString(u.Email));
                return res;
            }
            catch (Exception e) {
                logService.LogFatal(e);
#if DEBUG
                throw e;
#endif
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public override async Task<ActionResult<User>> Get(int id) {
            try {
                var res = await userRepository.GetAsync(id);
                res.Email = EncryptString(res.Email);
                return res;
            }
            catch (Exception e) {
                logService.LogFatal(e);
#if DEBUG
                throw e;
#endif
            }
            return BadRequest();
        }
        /// <summary>
        /// пример генерации RSA (без считывания ключей - генерируются сразу, только для тестов)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string EncryptString(string str) {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            
            var privateKey = RSA.ExportParameters(true);
            var publicKey = RSA.ExportParameters(false);

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            string toEncrypt = str;

            //Console.WriteLine($"To encode: {toEncrypt}");

            byte[] encBytes = RSACrypto.RSAEncrypt(byteConverter.GetBytes(toEncrypt), publicKey, false);

            string encrypt = byteConverter.GetString(encBytes);
            //Console.WriteLine("Encrypt str: " + encrypt);
            //Console.WriteLine("Encrypt bytes: " + string.Join(", ", encBytes));

            byte[] decBytes = RSACrypto.RSADecrypt(encBytes, privateKey, false);

            //Console.WriteLine("Decrypt str: " + byteConverter.GetString(decBytes));
            //Console.WriteLine("Decrypt bytes: " + string.Join(", ", byteConverter.GetBytes(encrypt)));
            return encrypt;
        }
    }
}
