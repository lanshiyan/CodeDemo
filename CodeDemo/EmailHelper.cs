using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace CodeDemo
{
    public class EmailHelper
    {
        #region 字段属性

        /// <summary>
        /// 发件箱服务器
        /// </summary>
        public string SendServer { get; set; }

        /// <summary>
        /// 收件人邮箱，多人以“;”分割
        /// </summary>
        public string ToMail { get; set; }
        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string FromMail { get; set; }
        /// <summary>
        /// 发件人密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string EmailBody { get; set; }
        /// <summary>
        /// 发送邮件的端口，默认是25
        /// </summary>
        private string prot = "25";
        /// <summary>
        /// 是否使用socket加密传输
        /// </summary>
        public bool SslEnable { get; set; }
        /// <summary>
        /// 是否对发件人邮箱进行密码验证
        /// </summary>
        public bool PwdCheckEnable { get; set; }

        /// <summary>
        /// 发送邮件的端口，默认是25
        /// </summary>
        public string Prot
        {
            get { return prot; }
            set { prot = value; }
        }

        /// <summary>
        /// 邮件
        /// </summary>
        private MailMessage mailMessage;
        /// <summary>
        /// 发件服务器
        /// </summary>
        private SmtpClient smtpClient;

        private string username;

        #endregion

        #region 构造方法

        /// <param name="tomail">收件箱地址,可以使用;隔开多个收件人地址</param>
        /// <param name="frommail">发件箱地址</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="emailbody">邮件内容</param>
        /// <param name="pwd">发件箱密码</param>
        /// <param name="sslEnable">是否ssl加密传输</param>
        /// <param name="pwdcheckEnable">是否验证发件人邮箱密码</param>
        public EmailHelper(string tomail, string frommail, string pwd, string subject, string emailbody, bool sslEnable = true, bool pwdcheckEnable = true)
            : this(SmtpClientComm.GetSmtp(frommail), tomail, frommail, pwd, subject, emailbody, sslEnable, pwdcheckEnable) { }

        /// <summary>
        /// 不常用的邮件服务器
        /// </summary>
        /// <param name="stmpclient">不常用的邮件服务器</param>
        /// <param name="tomail">收件箱地址,可以使用;隔开多个收件人地址</param>
        /// <param name="frommail">发件箱地址</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="emailbody">邮件内容</param>
        /// <param name="pwd">发件箱密码</param>
        /// <param name="sslEnable">是否ssl加密传输</param>
        /// <param name="pwdcheckEnable">是否验证发件人邮箱密码</param>
        public EmailHelper(string stmpclient, string tomail, string frommail, string pwd, string subject, string emailbody, bool sslEnable = true, bool pwdcheckEnable = true)
        {
            ToMail = tomail;
            FromMail = frommail;
            Subject = subject;
            EmailBody = emailbody;
            Pwd = pwd;
            SslEnable = sslEnable;
            PwdCheckEnable = pwdcheckEnable;
            username = frommail.Substring(0, frommail.IndexOf("@", StringComparison.Ordinal));
            SendServer = stmpclient;
        }

        #endregion

        #region 初始化
        /// <summary>
        /// 初始化邮件服务器
        /// </summary>
        private void InitSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Host = SendServer;
            smtpClient.Port = Convert.ToInt32(Prot);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.EnableSsl = SslEnable;
            smtpClient.Credentials = new NetworkCredential(username, Pwd);
        }

        /// <summary>
        /// 初始化邮件信息
        /// </summary>
        private void InitMailMessage()
        {
            mailMessage = new MailMessage();
            mailMessage.To.Add(ToMail);
            if (ToMail.Contains(";"))
            {
                mailMessage.To.Clear();
                foreach (var item in ToMail.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.To.Add(item);
                }
            }
            mailMessage.From = new MailAddress(FromMail, username);
            mailMessage.Subject = Subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.Body = EmailBody;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
        }
        #endregion

        /// <summary>
        /// 发送邮件,不附加附件
        /// </summary>
        public void SendWithoutAttachments()
        {
            InitMailMessage();
            InitSmtpClient();
            try
            {
                if (mailMessage != null)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 添加附件，多个附件使用“;”隔开
        /// </summary>
        public void SendWithAddAttachments(string paths)
        {
            InitMailMessage();
            InitSmtpClient();
            try
            {
                if (mailMessage != null)
                {   //添加附件
                    string[] path = paths.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    Attachment data;
                    ContentDisposition disposition;
                    for (int i = 0; i < path.Length; i++)
                    {
                        data = new Attachment(path[i], MediaTypeNames.Application.Octet);
                        disposition = data.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(path[i]);
                        disposition.ModificationDate = File.GetLastWriteTime(path[i]);
                        disposition.ReadDate = File.GetLastAccessTime(path[i]);
                        mailMessage.Attachments.Add(data);
                    }
                    //发送邮件
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    /// <summary>
    /// 常用的stmp服务器
    /// </summary>
    public class SmtpClientComm
    {

        public const string Smtp163 = "smtp.163.com";

        public const string Smtp126 = "smtp.126.com";

        public const string SmtpQQ = "smtp.qq.com";

        public const string Smtp188 = "smtp.188.com";

        public const string SmtpYeah = "smtp.yeah.net";

        public const string SmtpSina = "smtp.sina.com";

        public const string SmtpSohu = "smtp.sohu.com";

        public const string SmtpTom = "smtp.tom.com";

        public const string SmtpGmail = "smtp.gmail.com";

        public const string Smtp139 = "smtp.139.com";


        /// <summary>
        /// 根据发件箱获取邮件服务器
        /// </summary>
        public static string GetSmtp(string fromMail)
        {
            string stmp = string.Empty;
            if (string.IsNullOrEmpty(fromMail))
            {
                return "";
            }
            switch (fromMail.Substring(fromMail.IndexOf("@", StringComparison.Ordinal) + 1).ToLower())
            {
                case "126.com":
                    stmp = Smtp126; break;
                case "163.com":
                    stmp = Smtp163; break;
                case "qq.com":
                    stmp = SmtpQQ; break;
                case "188.com":
                    stmp = Smtp188; break;
                case "yeah.net":
                    stmp = SmtpYeah; break;
                case "sina.com":
                    stmp = SmtpSina; break;
                case "sohu.com":
                    stmp = SmtpSohu; break;
                case "tom.com":
                    stmp = SmtpTom; break;
                case "gmail.com":
                    stmp = SmtpGmail; break;
                case "139.com":
                    stmp = Smtp139; break;
            }
            if (string.IsNullOrEmpty(stmp))
            {
                throw new Exception("未找到对应的邮件服务器");
            }
            return stmp;
        }
    }
}