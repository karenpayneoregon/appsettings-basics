using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NorthWindCoreLibrary.LanguageExtensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Determine if a connection can be made asynchronously
        /// </summary>
        /// <param name="context"><see cref="DbContext"/></param>
        /// <returns></returns>
        public static async Task<bool> TestConnection(this DbContext context) =>
            await Task.Run(async () => await context.Database.CanConnectAsync());

        /// <summary>
        /// Determine if a connection can be made asynchronously with <see cref="CancellationToken"/>
        /// </summary>
        /// <param name="context"><see cref="DbContext"/></param>
        /// <param name="token">&lt;see cref="CancellationToken"/&gt;</param>
        /// <returns></returns>
        public static async Task<bool> TestConnection(this DbContext context, CancellationToken token) =>
            await Task.Run(async () => await context.Database.CanConnectAsync(token), token);
    }
}
