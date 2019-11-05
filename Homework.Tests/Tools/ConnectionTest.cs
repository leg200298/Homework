using Homework.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Tests.Tools
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void ConnectionStatus()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            var dbConnection = connectionFactory.CreateConnection();
            Assert.IsNotNull(dbConnection);
        }
    }
}
