using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //библиотека работы с файлами
using System.Threading;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using OpenPop.Pop3; //устанавливается через консоль NuGet - Install-Package OpenPop.NET

namespace MailSender
{
    public partial class MailSenderForm : Form
    {
        int all_account = 1; //необходимая переменная для запоминания ипользуемых аккаунтов
        bool check_error = true; //необходимая переменная указывающая что в данных аккаунта есть ошибка, не позволяющая делать рассылку

        public MailSenderForm()
        {
            InitializeComponent();
        }

        public void add_two_param() //процедура при двух указанных параметров аккаунта
        {
            //делаем видимыми третью форму для добавления аккаунта
            btn_add_3.Visible = true;
            check_domen_3.Visible = true;
            txt_email_3.Visible = true;
            txt_password_3.Visible = true;
            txt_smtp_3.Visible = true;
            txt_port_3.Visible = true;
            check_ssl_3.Visible = true;

            //активируем возможность добавления второго аккаунта
            check_domen_2.Enabled = true;
            txt_email_2.Enabled = true;
            txt_password_2.Enabled = true;
            txt_smtp_2.Enabled = true;
            txt_port_2.Enabled = true;
            check_ssl_2.Enabled = true;

            //на втором аккаунте убираем кнопку добавления третьего аккаунта и на его место ставим кнопку удаления второго аккаунта
            btn_add_2.Visible = false;
            btn_del_2.Visible = true;

            //запоминаем что используется два аккаунта
            all_account = 2;
        }

        public void add_three_param() //процедура при трех указанных параметров аккаунта
        {
            //делаем видимыми четвертую форму для добавления аккаунта
            btn_add_4.Visible = true;
            check_domen_4.Visible = true;
            txt_email_4.Visible = true;
            txt_password_4.Visible = true;
            txt_smtp_4.Visible = true;
            txt_port_4.Visible = true;
            check_ssl_4.Visible = true;

            //активируем возможность добавления третьего аккаунта
            check_domen_3.Enabled = true;
            txt_email_3.Enabled = true;
            txt_password_3.Enabled = true;
            txt_smtp_3.Enabled = true;
            txt_port_3.Enabled = true;
            check_ssl_3.Enabled = true;

            //на третьем аккаунте убираем кнопку добавления третьего аккаунта и на его место ставим кнопку удаления третьего аккаунта
            btn_add_3.Visible = false;
            btn_del_3.Visible = true;

            //на втором аккаунте убираем из видимости кнопку удаления аккаунта
            btn_del_2.Visible = false;

            //запоминаем что используется три аккаунта
            all_account = 3;
        }

        public void add_four_param() //процедура при четырех указанных параметров аккаунта
        {
            //делаем видимыми пятую форму для добавления аккаунта
            btn_add_5.Visible = true;
            check_domen_5.Visible = true;
            txt_email_5.Visible = true;
            txt_password_5.Visible = true;
            txt_smtp_5.Visible = true;
            txt_port_5.Visible = true;
            check_ssl_5.Visible = true;

            //активируем возможность добавления четвертого аккаунта
            check_domen_4.Enabled = true;
            txt_email_4.Enabled = true;
            txt_password_4.Enabled = true;
            txt_smtp_4.Enabled = true;
            txt_port_4.Enabled = true;
            check_ssl_4.Enabled = true;

            //на четвертом аккаунте убираем кнопку добавления пятого аккаунта и на его место ставим кнопку удаления четвертого аккаунта
            btn_add_4.Visible = false;
            btn_del_4.Visible = true;

            //на третьем аккаунте убираем из видимости кнопку удаления аккаунта
            btn_del_3.Visible = false;

            //запоминаем что используется четыре аккаунта
            all_account = 4;
        }

        public void add_five_param() //процедура при пяти указанных параметров аккаунта
        {
            //активируем возможность добавления пятого аккаунта
            check_domen_5.Enabled = true;
            txt_email_5.Enabled = true;
            txt_password_5.Enabled = true;
            txt_smtp_5.Enabled = true;
            txt_port_5.Enabled = true;
            check_ssl_5.Enabled = true;

            //на пятом аккаунте убираем кнопку добавления и на его место ставим кнопку удаления пятого аккаунта
            btn_add_5.Visible = false;
            btn_del_5.Visible = true;

            //на четвертом аккаунте убираем из видимости кнопку удаления аккаунта
            btn_del_4.Visible = false;

            //запоминаем что используется пять аккаунтов
            all_account = 5;
        }

        public void del_two_param() //процедура удаления второго аккаунта
        {
            //деактивируем вторую форму
            check_domen_2.Enabled = false;
            txt_email_2.Enabled = false;
            txt_password_2.Enabled = false;
            txt_smtp_2.Enabled = false;
            txt_port_2.Enabled = false;
            check_ssl_2.Enabled = false;

            //убираем из виду третью форму аккаунта
            check_domen_3.Visible = false;
            txt_email_3.Visible = false;
            txt_password_3.Visible = false;
            txt_smtp_3.Visible = false;
            txt_port_3.Visible = false;
            check_ssl_3.Visible = false;

            //очищаем поле второго аккаунта
            check_domen_2.Text = "";
            txt_email_2.Text = "";
            txt_password_2.Text = "";
            txt_smtp_2.Text = "";
            txt_port_2.Text = "";
            check_ssl_2.Checked = false;

            //убираем кнопку добавления третьего аккаунта
            btn_add_3.Visible = false;

            //убираем кнопку удаления второго аккаунта и возвращаем кнопку добавления второго аккаунта
            btn_del_2.Visible = false;
            btn_add_2.Visible = true;

            //запоминаем что используется один аккаунт
            all_account = 1;
        }

        public void del_three_param() //процедура удаления третьего аккаунта
        {
            //деактивируем третью форму
            check_domen_3.Enabled = false;
            txt_email_3.Enabled = false;
            txt_password_3.Enabled = false;
            txt_smtp_3.Enabled = false;
            txt_port_3.Enabled = false;
            check_ssl_3.Enabled = false;

            //убираем из виду четвертую форму аккаунта
            check_domen_4.Visible = false;
            txt_email_4.Visible = false;
            txt_password_4.Visible = false;
            txt_smtp_4.Visible = false;
            txt_port_4.Visible = false;
            check_ssl_4.Visible = false;

            //очищаем поле третьего аккаунта
            check_domen_3.Text = "";
            txt_email_3.Text = "";
            txt_password_3.Text = "";
            txt_smtp_3.Text = "";
            txt_port_3.Text = "";
            check_ssl_3.Checked = false;

            //убираем кнопку добавления четвертого аккаунта
            btn_add_4.Visible = false;

            //убираем кнопку удаления третьего аккаунта и возвращаем кнопку добавления третьего аккаунта
            btn_del_3.Visible = false;
            btn_add_3.Visible = true;

            //возвращаем кнопку удаления второго аккаунта
            btn_del_2.Visible = true;

            //запоминаем что используется два аккаунта
            all_account = 2;
        }

        public void del_four_param() //процедура удаления четвертого аккаунта
        {
            //деактивируем четвертую форму
            check_domen_4.Enabled = false;
            txt_email_4.Enabled = false;
            txt_password_4.Enabled = false;
            txt_smtp_4.Enabled = false;
            txt_port_4.Enabled = false;
            check_ssl_4.Enabled = false;

            //убираем из виду пятую форму аккаунта
            check_domen_5.Visible = false;
            txt_email_5.Visible = false;
            txt_password_5.Visible = false;
            txt_smtp_5.Visible = false;
            txt_port_5.Visible = false;
            check_ssl_5.Visible = false;

            //очищаем поле четвертого аккаунта
            check_domen_4.Text = "";
            txt_email_4.Text = "";
            txt_password_4.Text = "";
            txt_smtp_4.Text = "";
            txt_port_4.Text = "";
            check_ssl_4.Checked = false;

            //убираем кнопку добавления пятого аккаунта
            btn_add_5.Visible = false;

            //убираем кнопку удаления четвертого аккаунта и возвращаем кнопку добавления четвертого аккаунта
            btn_del_4.Visible = false;
            btn_add_4.Visible = true;

            //возвращаем кнопку удаления третьего аккаунта
            btn_del_3.Visible = true;

            //запоминаем что используется три аккаунта
            all_account = 3;
        }

        public void del_five_param() //процедура удаления пятого аккаунта
        {
            //деактивируем пятую форму
            check_domen_5.Enabled = false;
            txt_email_5.Enabled = false;
            txt_password_5.Enabled = false;
            txt_smtp_5.Enabled = false;
            txt_port_5.Enabled = false;
            check_ssl_5.Enabled = false;

            //очищаем поле пятого аккаунта
            check_domen_5.Text = "";
            txt_email_5.Text = "";
            txt_password_5.Text = "";
            txt_smtp_5.Text = "";
            txt_port_5.Text = "";
            check_ssl_5.Checked = false;

            //убираем кнопку удаления пятого аккаунта и возвращаем кнопку добавления пятого аккаунта
            btn_del_5.Visible = false;
            btn_add_5.Visible = true;

            //возвращаем кнопку удаления четвертого аккаунта
            btn_del_4.Visible = true;

            //запоминаем что используется четыре аккаунта
            all_account = 4;
        }

        public void save_param() //процедура сохранения всех параметров, в том числе аккаунтов
        {
            if (all_account == 1)
                File.WriteAllLines("connect.txt", new string[] { all_account.ToString(), txt_time_send.Text, check_domen_1.Text,
                txt_email_1.Text, txt_password_1.Text, txt_smtp_1.Text, txt_port_1.Text, check_ssl_1.Checked.ToString()});
            else if (all_account == 2)
                File.WriteAllLines("connect.txt", new string[] { all_account.ToString(), txt_time_send.Text, check_domen_1.Text,
                txt_email_1.Text, txt_password_1.Text, txt_smtp_1.Text, txt_port_1.Text, check_ssl_1.Checked.ToString(),
                check_domen_2.Text, txt_email_2.Text, txt_password_2.Text, txt_smtp_2.Text, txt_port_2.Text, check_ssl_2.Checked.ToString()});
            else if (all_account == 3)
                File.WriteAllLines("connect.txt", new string[] { all_account.ToString(), txt_time_send.Text, check_domen_1.Text,
                txt_email_1.Text, txt_password_1.Text, txt_smtp_1.Text, txt_port_1.Text, check_ssl_1.Checked.ToString(),
                check_domen_2.Text, txt_email_2.Text, txt_password_2.Text, txt_smtp_2.Text, txt_port_2.Text, check_ssl_2.Checked.ToString(),
                check_domen_3.Text, txt_email_3.Text, txt_password_3.Text, txt_smtp_3.Text, txt_port_3.Text, check_ssl_3.Checked.ToString()});
            else if (all_account == 4)
                File.WriteAllLines("connect.txt", new string[] { all_account.ToString(), txt_time_send.Text, check_domen_1.Text,
                txt_email_1.Text, txt_password_1.Text, txt_smtp_1.Text, txt_port_1.Text, check_ssl_1.Checked.ToString(),
                check_domen_2.Text, txt_email_2.Text, txt_password_2.Text, txt_smtp_2.Text, txt_port_2.Text, check_ssl_2.Checked.ToString(),
                check_domen_3.Text, txt_email_3.Text, txt_password_3.Text, txt_smtp_3.Text, txt_port_3.Text, check_ssl_3.Checked.ToString(),
                check_domen_4.Text, txt_email_4.Text, txt_password_4.Text, txt_smtp_4.Text, txt_port_4.Text, check_ssl_4.Checked.ToString()});
            else if (all_account == 5)
                File.WriteAllLines("connect.txt", new string[] { all_account.ToString(), txt_time_send.Text, check_domen_1.Text,
                txt_email_1.Text, txt_password_1.Text, txt_smtp_1.Text, txt_port_1.Text, check_ssl_1.Checked.ToString(),
                check_domen_2.Text, txt_email_2.Text, txt_password_2.Text, txt_smtp_2.Text, txt_port_2.Text, check_ssl_2.Checked.ToString(),
                check_domen_3.Text, txt_email_3.Text, txt_password_3.Text, txt_smtp_3.Text, txt_port_3.Text, check_ssl_3.Checked.ToString(),
                check_domen_4.Text, txt_email_4.Text, txt_password_4.Text, txt_smtp_4.Text, txt_port_4.Text, check_ssl_4.Checked.ToString(),
                check_domen_5.Text, txt_email_5.Text, txt_password_5.Text, txt_smtp_5.Text, txt_port_5.Text, check_ssl_5.Checked.ToString()});
        }

        public void load_param() //процедура загрузки всех параметров из файла
        {
            string curFile = "connect.txt";
            if (File.Exists(curFile) == true)
            {
                if ("1" == Convert.ToString(File.ReadAllLines(curFile)[0]))
                {
                    all_account = Convert.ToInt32(File.ReadAllLines(curFile)[0]);
                    txt_time_send.Text = Convert.ToString(File.ReadAllLines(curFile)[1]);
                    check_domen_1.Text = Convert.ToString(File.ReadAllLines(curFile)[2]);
                    txt_email_1.Text = Convert.ToString(File.ReadAllLines(curFile)[3]); 
                    txt_password_1.Text = Convert.ToString(File.ReadAllLines(curFile)[4]); 
                    txt_smtp_1.Text = Convert.ToString(File.ReadAllLines(curFile)[5]);
                    txt_port_1.Text = Convert.ToString(File.ReadAllLines(curFile)[6]);
                    check_ssl_1.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[7]);
                }
                else if ("2" == Convert.ToString(File.ReadAllLines(curFile)[0]))
                {
                    all_account = Convert.ToInt32(File.ReadAllLines(curFile)[0]);
                    txt_time_send.Text = Convert.ToString(File.ReadAllLines(curFile)[1]);
                    check_domen_1.Text = Convert.ToString(File.ReadAllLines(curFile)[2]);
                    txt_email_1.Text = Convert.ToString(File.ReadAllLines(curFile)[3]);
                    txt_password_1.Text = Convert.ToString(File.ReadAllLines(curFile)[4]);
                    txt_smtp_1.Text = Convert.ToString(File.ReadAllLines(curFile)[5]);
                    txt_port_1.Text = Convert.ToString(File.ReadAllLines(curFile)[6]);
                    check_ssl_1.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[7]);
                    check_domen_2.Text = Convert.ToString(File.ReadAllLines(curFile)[8]);
                    txt_email_2.Text = Convert.ToString(File.ReadAllLines(curFile)[9]);
                    txt_password_2.Text = Convert.ToString(File.ReadAllLines(curFile)[10]);
                    txt_smtp_2.Text = Convert.ToString(File.ReadAllLines(curFile)[11]);
                    txt_port_2.Text = Convert.ToString(File.ReadAllLines(curFile)[12]);
                    check_ssl_2.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[13]);
                    add_two_param();
                }
                else if ("3" == Convert.ToString(File.ReadAllLines(curFile)[0]))
                {
                    all_account = Convert.ToInt32(File.ReadAllLines(curFile)[0]);
                    txt_time_send.Text = Convert.ToString(File.ReadAllLines(curFile)[1]);
                    check_domen_1.Text = Convert.ToString(File.ReadAllLines(curFile)[2]);
                    txt_email_1.Text = Convert.ToString(File.ReadAllLines(curFile)[3]);
                    txt_password_1.Text = Convert.ToString(File.ReadAllLines(curFile)[4]);
                    txt_smtp_1.Text = Convert.ToString(File.ReadAllLines(curFile)[5]);
                    txt_port_1.Text = Convert.ToString(File.ReadAllLines(curFile)[6]);
                    check_ssl_1.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[7]);
                    check_domen_2.Text = Convert.ToString(File.ReadAllLines(curFile)[8]);
                    txt_email_2.Text = Convert.ToString(File.ReadAllLines(curFile)[9]);
                    txt_password_2.Text = Convert.ToString(File.ReadAllLines(curFile)[10]);
                    txt_smtp_2.Text = Convert.ToString(File.ReadAllLines(curFile)[11]);
                    txt_port_2.Text = Convert.ToString(File.ReadAllLines(curFile)[12]);
                    check_ssl_2.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[13]);
                    check_domen_3.Text = Convert.ToString(File.ReadAllLines(curFile)[14]);
                    txt_email_3.Text = Convert.ToString(File.ReadAllLines(curFile)[15]);
                    txt_password_3.Text = Convert.ToString(File.ReadAllLines(curFile)[16]);
                    txt_smtp_3.Text = Convert.ToString(File.ReadAllLines(curFile)[17]);
                    txt_port_3.Text = Convert.ToString(File.ReadAllLines(curFile)[18]);
                    check_ssl_3.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[19]);
                    add_two_param(); add_three_param();
                }
                else if ("4" == Convert.ToString(File.ReadAllLines(curFile)[0]))
                {
                    all_account = Convert.ToInt32(File.ReadAllLines(curFile)[0]);
                    txt_time_send.Text = Convert.ToString(File.ReadAllLines(curFile)[1]);
                    check_domen_1.Text = Convert.ToString(File.ReadAllLines(curFile)[2]);
                    txt_email_1.Text = Convert.ToString(File.ReadAllLines(curFile)[3]);
                    txt_password_1.Text = Convert.ToString(File.ReadAllLines(curFile)[4]);
                    txt_smtp_1.Text = Convert.ToString(File.ReadAllLines(curFile)[5]);
                    txt_port_1.Text = Convert.ToString(File.ReadAllLines(curFile)[6]);
                    check_ssl_1.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[7]);
                    check_domen_2.Text = Convert.ToString(File.ReadAllLines(curFile)[8]);
                    txt_email_2.Text = Convert.ToString(File.ReadAllLines(curFile)[9]);
                    txt_password_2.Text = Convert.ToString(File.ReadAllLines(curFile)[10]);
                    txt_smtp_2.Text = Convert.ToString(File.ReadAllLines(curFile)[11]);
                    txt_port_2.Text = Convert.ToString(File.ReadAllLines(curFile)[12]);
                    check_ssl_2.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[13]);
                    check_domen_3.Text = Convert.ToString(File.ReadAllLines(curFile)[14]);
                    txt_email_3.Text = Convert.ToString(File.ReadAllLines(curFile)[15]);
                    txt_password_3.Text = Convert.ToString(File.ReadAllLines(curFile)[16]);
                    txt_smtp_3.Text = Convert.ToString(File.ReadAllLines(curFile)[17]);
                    txt_port_3.Text = Convert.ToString(File.ReadAllLines(curFile)[18]);
                    check_ssl_3.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[19]);
                    check_domen_4.Text = Convert.ToString(File.ReadAllLines(curFile)[20]);
                    txt_email_4.Text = Convert.ToString(File.ReadAllLines(curFile)[21]);
                    txt_password_4.Text = Convert.ToString(File.ReadAllLines(curFile)[22]);
                    txt_smtp_4.Text = Convert.ToString(File.ReadAllLines(curFile)[23]);
                    txt_port_4.Text = Convert.ToString(File.ReadAllLines(curFile)[24]);
                    check_ssl_4.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[25]);
                    add_two_param(); add_three_param(); add_four_param();
                }
                else if ("5" == Convert.ToString(File.ReadAllLines(curFile)[0]))
                {
                    all_account = Convert.ToInt32(File.ReadAllLines(curFile)[0]);
                    txt_time_send.Text = Convert.ToString(File.ReadAllLines(curFile)[1]);
                    check_domen_1.Text = Convert.ToString(File.ReadAllLines(curFile)[2]);
                    txt_email_1.Text = Convert.ToString(File.ReadAllLines(curFile)[3]);
                    txt_password_1.Text = Convert.ToString(File.ReadAllLines(curFile)[4]);
                    txt_smtp_1.Text = Convert.ToString(File.ReadAllLines(curFile)[5]);
                    txt_port_1.Text = Convert.ToString(File.ReadAllLines(curFile)[6]);
                    check_ssl_1.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[7]);
                    check_domen_2.Text = Convert.ToString(File.ReadAllLines(curFile)[8]);
                    txt_email_2.Text = Convert.ToString(File.ReadAllLines(curFile)[9]);
                    txt_password_2.Text = Convert.ToString(File.ReadAllLines(curFile)[10]);
                    txt_smtp_2.Text = Convert.ToString(File.ReadAllLines(curFile)[11]);
                    txt_port_2.Text = Convert.ToString(File.ReadAllLines(curFile)[12]);
                    check_ssl_2.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[13]);
                    check_domen_3.Text = Convert.ToString(File.ReadAllLines(curFile)[14]);
                    txt_email_3.Text = Convert.ToString(File.ReadAllLines(curFile)[15]);
                    txt_password_3.Text = Convert.ToString(File.ReadAllLines(curFile)[16]);
                    txt_smtp_3.Text = Convert.ToString(File.ReadAllLines(curFile)[17]);
                    txt_port_3.Text = Convert.ToString(File.ReadAllLines(curFile)[18]);
                    check_ssl_3.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[19]);
                    check_domen_4.Text = Convert.ToString(File.ReadAllLines(curFile)[20]);
                    txt_email_4.Text = Convert.ToString(File.ReadAllLines(curFile)[21]);
                    txt_password_4.Text = Convert.ToString(File.ReadAllLines(curFile)[22]);
                    txt_smtp_4.Text = Convert.ToString(File.ReadAllLines(curFile)[23]);
                    txt_port_4.Text = Convert.ToString(File.ReadAllLines(curFile)[24]);
                    check_ssl_4.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[25]);
                    check_domen_5.Text = Convert.ToString(File.ReadAllLines(curFile)[26]);
                    txt_email_5.Text = Convert.ToString(File.ReadAllLines(curFile)[27]);
                    txt_password_5.Text = Convert.ToString(File.ReadAllLines(curFile)[28]);
                    txt_smtp_5.Text = Convert.ToString(File.ReadAllLines(curFile)[29]);
                    txt_port_5.Text = Convert.ToString(File.ReadAllLines(curFile)[30]);
                    check_ssl_5.Checked = Convert.ToBoolean(File.ReadAllLines(curFile)[31]);
                    add_two_param(); add_three_param(); add_four_param(); add_five_param();
                }
            }
        }

        public void check_param() //проверка введённых данных аккаунта
        {
            if (all_account == 1)
            {
                if (check_domen_1.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if(txt_email_1.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_1.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_1.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_1.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_1.Text != "" && txt_email_1.Text != "" && txt_password_1.Text != "" && txt_smtp_1.Text != "" && txt_port_1.Text != "")
                    check_error = false;
            }
            if (all_account == 2)
            {
                if (check_domen_1.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_1.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_1.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_1.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_1.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_2.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_2.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_2.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_2.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_2.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_1.Text != "" && txt_email_1.Text != "" && txt_password_1.Text != "" && txt_smtp_1.Text != "" && txt_port_1.Text != ""
                        && check_domen_2.Text != "" && txt_email_2.Text != "" && txt_password_2.Text != "" && txt_smtp_2.Text != "" && txt_port_2.Text != "")
                    check_error = false;
            }
            if (all_account == 3)
            {
                if (check_domen_1.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_1.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_1.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_1.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_1.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_2.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_2.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_2.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_2.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_2.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_3.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_3.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_3.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_3.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_3.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_1.Text != "" && txt_email_1.Text != "" && txt_password_1.Text != "" && txt_smtp_1.Text != "" && txt_port_1.Text != ""
                        && check_domen_2.Text != "" && txt_email_2.Text != "" && txt_password_2.Text != "" && txt_smtp_2.Text != "" && txt_port_2.Text != ""
                        && check_domen_3.Text != "" && txt_email_3.Text != "" && txt_password_3.Text != "" && txt_smtp_3.Text != "" && txt_port_3.Text != "")
                    check_error = false;
            }
            if (all_account == 4)
            {
                if (check_domen_1.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_1.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_1.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_1.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_1.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_2.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_2.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_2.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_2.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_2.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_3.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_3.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_3.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_3.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_3.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_4.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_4.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_4.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_4.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_4.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_1.Text != "" && txt_email_1.Text != "" && txt_password_1.Text != "" && txt_smtp_1.Text != "" && txt_port_1.Text != ""
                        && check_domen_2.Text != "" && txt_email_2.Text != "" && txt_password_2.Text != "" && txt_smtp_2.Text != "" && txt_port_2.Text != ""
                        && check_domen_3.Text != "" && txt_email_3.Text != "" && txt_password_3.Text != "" && txt_smtp_3.Text != "" && txt_port_3.Text != ""
                        && check_domen_4.Text != "" && txt_email_4.Text != "" && txt_password_4.Text != "" && txt_smtp_4.Text != "" && txt_port_4.Text != "")
                    check_error = false;
            }
            if (all_account == 5)
            {
                if (check_domen_1.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_1.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_1.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_1.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_1.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_2.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_2.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_2.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_2.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_2.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_3.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_3.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_3.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_3.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_3.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_4.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_4.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_4.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_4.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_4.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_5.Text == "")
                    MessageBox.Show("Домен не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_email_5.Text == "")
                    MessageBox.Show("Почтовой ящик не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_password_5.Text == "")
                    MessageBox.Show("Пароль не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_smtp_5.Text == "")
                    MessageBox.Show("SMTP не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (txt_port_5.Text == "")
                    MessageBox.Show("Порт не может быть указан пустым", "Ошибка данных аккаунта", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (check_domen_1.Text != "" && txt_email_1.Text != "" && txt_password_1.Text != "" && txt_smtp_1.Text != "" && txt_port_1.Text != ""
                        && check_domen_2.Text != "" && txt_email_2.Text != "" && txt_password_2.Text != "" && txt_smtp_2.Text != "" && txt_port_2.Text != ""
                        && check_domen_3.Text != "" && txt_email_3.Text != "" && txt_password_3.Text != "" && txt_smtp_3.Text != "" && txt_port_3.Text != ""
                        && check_domen_4.Text != "" && txt_email_4.Text != "" && txt_password_4.Text != "" && txt_smtp_4.Text != "" && txt_port_4.Text != ""
                        && check_domen_5.Text != "" && txt_email_5.Text != "" && txt_password_5.Text != "" && txt_smtp_5.Text != "" && txt_port_5.Text != "")
                    check_error = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_two_param();
        }

        private void btn_del_2_Click(object sender, EventArgs e)
        {
            del_two_param();
        }

        private void btn_add_3_Click(object sender, EventArgs e)
        {
            add_three_param();
        }

        private void btn_del_3_Click(object sender, EventArgs e)
        {
            del_three_param();
        }

        private void btn_add_4_Click(object sender, EventArgs e)
        {
            add_four_param();
        }

        private void btn_add_5_Click(object sender, EventArgs e)
        {
            add_five_param();
        }

        private void btn_del_4_Click(object sender, EventArgs e)
        {
            del_four_param();
        }

        private void btn_del_5_Click(object sender, EventArgs e)
        {
            del_five_param();
        }

        private void txt_send_mail_TextChanged(object sender, EventArgs e)
        {
           lbl_all_send.Text = txt_send_mail.Lines.Length.ToString();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            check_param(); //проверяем на наличие ошибок заполненния аккаунтов
            if (check_error == false)
            {
                save_param(); //сохраняем все параметры при остутствии ошибок
                int i = 0; //счётчик всех писем
                int turn = 1; //счётчик очереди
                string s = txt_send_mail.Text;
                string[] split = s.Split('\n');
                foreach (string adr in split)
                {
                    if (adr == "")
                    {
                        continue;
                    }
                    if (all_account == 1) //если 1 аккаунт, то рассылка с одного
                    {
                        MailMessage mail = new MailMessage(txt_email_1.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client = new SmtpClient(txt_smtp_1.Text);
                        client.Port = Int16.Parse(txt_port_1.Text);
                        client.Credentials = new System.Net.NetworkCredential(txt_email_1.Text, txt_password_1.Text);
                        client.EnableSsl = check_ssl_1.Checked;
                        i += 1;
                        if (i == 1)
                        {
                            txt_result_mail.Text = "Разослано 1 адресату";
                        }
                        else txt_result_mail.Text = "Разослано " + i + " адресатам";
                        try
                        {
                            client.Send(mail);
                            Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                    else if (all_account == 2) //если 2 аккаунта, то рассылка с двух
                    {
                        //первый аккаунт
                        MailMessage mail_1 = new MailMessage(txt_email_1.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_1 = new SmtpClient(txt_smtp_1.Text);
                        client_1.Port = Int16.Parse(txt_port_1.Text);
                        client_1.Credentials = new System.Net.NetworkCredential(txt_email_1.Text, txt_password_1.Text);
                        client_1.EnableSsl = check_ssl_1.Checked;
                        //второй аккаунт
                        MailMessage mail_2 = new MailMessage(txt_email_2.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_2 = new SmtpClient(txt_smtp_2.Text);
                        client_2.Port = Int16.Parse(txt_port_2.Text);
                        client_2.Credentials = new System.Net.NetworkCredential(txt_email_2.Text, txt_password_2.Text);
                        client_2.EnableSsl = check_ssl_2.Checked;
                        i += 1;
                        if (i == 1)
                        {
                            txt_result_mail.Text = "Разослано 1 адресату";
                        }
                        else txt_result_mail.Text = "Разослано " + i + " адресатам";
                        try
                        {
                            if (turn == 1) //если очередь первая, выполняем и ставим в очередь вторую
                            { 
                                client_1.Send(mail_1);
                                turn = 2;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 2) //если очередь вторая, выполняем и ставим в первую очередь
                            {
                                client_2.Send(mail_2);
                                turn = 1;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                    else if (all_account == 3) //если 3 аккаунта, то рассылка с трёх
                    {
                        //первый аккаунт
                        MailMessage mail_1 = new MailMessage(txt_email_1.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_1 = new SmtpClient(txt_smtp_1.Text);
                        client_1.Port = Int16.Parse(txt_port_1.Text);
                        client_1.Credentials = new System.Net.NetworkCredential(txt_email_1.Text, txt_password_1.Text);
                        client_1.EnableSsl = check_ssl_1.Checked;
                        //второй аккаунт
                        MailMessage mail_2 = new MailMessage(txt_email_2.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_2 = new SmtpClient(txt_smtp_2.Text);
                        client_2.Port = Int16.Parse(txt_port_2.Text);
                        client_2.Credentials = new System.Net.NetworkCredential(txt_email_2.Text, txt_password_2.Text);
                        client_2.EnableSsl = check_ssl_2.Checked;
                        //третий аккаунт
                        MailMessage mail_3 = new MailMessage(txt_email_3.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_3 = new SmtpClient(txt_smtp_3.Text);
                        client_3.Port = Int16.Parse(txt_port_3.Text);
                        client_3.Credentials = new System.Net.NetworkCredential(txt_email_3.Text, txt_password_3.Text);
                        client_3.EnableSsl = check_ssl_3.Checked;
                        i += 1;
                        if (i == 1)
                        {
                            txt_result_mail.Text = "Разослано 1 адресату";
                        }
                        else txt_result_mail.Text = "Разослано " + i + " адресатам";
                        try
                        {
                            if (turn == 1) //если очередь первая, выполняем и ставим в очередь вторую
                            {
                                client_1.Send(mail_1);
                                turn = 2;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 2) //если очередь вторая, выполняем и ставим в третью очередь
                            {
                                client_2.Send(mail_2);
                                turn = 3;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 3) //если очередь третья, выполняем и ставим в первую очередь
                            {
                                client_3.Send(mail_3);
                                turn = 1;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                    else if (all_account == 4) //если 4 аккаунта, то рассылка с четырёх
                    {
                        //первый аккаунт
                        MailMessage mail_1 = new MailMessage(txt_email_1.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_1 = new SmtpClient(txt_smtp_1.Text);
                        client_1.Port = Int16.Parse(txt_port_1.Text);
                        client_1.Credentials = new System.Net.NetworkCredential(txt_email_1.Text, txt_password_1.Text);
                        client_1.EnableSsl = check_ssl_1.Checked;
                        //второй аккаунт
                        MailMessage mail_2 = new MailMessage(txt_email_2.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_2 = new SmtpClient(txt_smtp_2.Text);
                        client_2.Port = Int16.Parse(txt_port_2.Text);
                        client_2.Credentials = new System.Net.NetworkCredential(txt_email_2.Text, txt_password_2.Text);
                        client_2.EnableSsl = check_ssl_2.Checked;
                        //третий аккаунт
                        MailMessage mail_3 = new MailMessage(txt_email_3.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_3 = new SmtpClient(txt_smtp_3.Text);
                        client_3.Port = Int16.Parse(txt_port_3.Text);
                        client_3.Credentials = new System.Net.NetworkCredential(txt_email_3.Text, txt_password_3.Text);
                        client_3.EnableSsl = check_ssl_3.Checked;
                        //четвертый аккаунт
                        MailMessage mail_4 = new MailMessage(txt_email_4.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_4 = new SmtpClient(txt_smtp_4.Text);
                        client_4.Port = Int16.Parse(txt_port_4.Text);
                        client_4.Credentials = new System.Net.NetworkCredential(txt_email_4.Text, txt_password_4.Text);
                        client_4.EnableSsl = check_ssl_4.Checked;
                        i += 1;
                        if (i == 1)
                        {
                            txt_result_mail.Text = "Разослано 1 адресату";
                        }
                        else txt_result_mail.Text = "Разослано " + i + " адресатам";
                        try
                        {
                            if (turn == 1) //если очередь первая, выполняем и ставим в очередь вторую
                            {
                                client_1.Send(mail_1);
                                turn = 2;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 2) //если очередь вторая, выполняем и ставим в третью очередь
                            {
                                client_2.Send(mail_2);
                                turn = 3;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 3) //если очередь третья, выполняем и ставим в четвертую очередь
                            {
                                client_3.Send(mail_3);
                                turn = 4;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 4) //если очередь четвертая, выполняем и ставим в первую очередь
                            {
                                client_4.Send(mail_4);
                                turn = 1;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                    else if (all_account == 5) //если 5 аккаунтов, то рассылка с пятёрых
                    {
                        //первый аккаунт
                        MailMessage mail_1 = new MailMessage(txt_email_1.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_1 = new SmtpClient(txt_smtp_1.Text);
                        client_1.Port = Int16.Parse(txt_port_1.Text);
                        client_1.Credentials = new System.Net.NetworkCredential(txt_email_1.Text, txt_password_1.Text);
                        client_1.EnableSsl = check_ssl_1.Checked;
                        //второй аккаунт
                        MailMessage mail_2 = new MailMessage(txt_email_2.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_2 = new SmtpClient(txt_smtp_2.Text);
                        client_2.Port = Int16.Parse(txt_port_2.Text);
                        client_2.Credentials = new System.Net.NetworkCredential(txt_email_2.Text, txt_password_2.Text);
                        client_2.EnableSsl = check_ssl_2.Checked;
                        //третий аккаунт
                        MailMessage mail_3 = new MailMessage(txt_email_3.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_3 = new SmtpClient(txt_smtp_3.Text);
                        client_3.Port = Int16.Parse(txt_port_3.Text);
                        client_3.Credentials = new System.Net.NetworkCredential(txt_email_3.Text, txt_password_3.Text);
                        client_3.EnableSsl = check_ssl_3.Checked;
                        //четвертый аккаунт
                        MailMessage mail_4 = new MailMessage(txt_email_4.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_4 = new SmtpClient(txt_smtp_4.Text);
                        client_4.Port = Int16.Parse(txt_port_4.Text);
                        client_4.Credentials = new System.Net.NetworkCredential(txt_email_4.Text, txt_password_4.Text);
                        client_4.EnableSsl = check_ssl_4.Checked;
                        //пятый аккаунт
                        MailMessage mail_5 = new MailMessage(txt_email_5.Text, adr, txt_theme_mail.Text, txt_message_mail.Text);
                        SmtpClient client_5 = new SmtpClient(txt_smtp_5.Text);
                        client_5.Port = Int16.Parse(txt_port_5.Text);
                        client_5.Credentials = new System.Net.NetworkCredential(txt_email_5.Text, txt_password_5.Text);
                        client_5.EnableSsl = check_ssl_5.Checked;
                        i += 1;
                        if (i == 1)
                        {
                            txt_result_mail.Text = "Разослано 1 адресату";
                        }
                        else txt_result_mail.Text = "Разослано " + i + " адресатам";
                        try
                        {
                            if (turn == 1) //если очередь первая, выполняем и ставим в очередь вторую
                            {
                                client_1.Send(mail_1);
                                turn = 2;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 2) //если очередь вторая, выполняем и ставим в третью очередь
                            {
                                client_2.Send(mail_2);
                                turn = 3;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 3) //если очередь третья, выполняем и ставим в четвертую очередь
                            {
                                client_3.Send(mail_3);
                                turn = 4;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 4) //если очередь четвертая, выполняем и ставим в пятую очередь
                            {
                                client_4.Send(mail_4);
                                turn = 5;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                            else if (turn == 5) //если очередь пятая, выполняем и ставим в первую очередь
                            {
                                client_5.Send(mail_5);
                                turn = 1;
                                Thread.Sleep(Int16.Parse(txt_time_send.Text) * 1000);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void MailSenderForm_Load(object sender, EventArgs e) //при первом запуске приложения сразу загружать сохраненные данные, если они имеются
        {
            load_param();
        }

        private void txt_send_mail_KeyDown(object sender, KeyEventArgs e) //адресаты указываются в текстовом типе
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                txt_send_mail.Text += (string)Clipboard.GetData("Text");
                e.Handled = true;
            }
        }

        private void check_domen_1_SelectedIndexChanged(object sender, EventArgs e) //при выборке заполнять поля стандартными значениями
        {
            if (check_domen_1.Text == "Mail.ru")
            {
                txt_smtp_1.Text = "smtp.mail.ru";
                txt_port_1.Text = "25";
                check_ssl_1.Checked = true;
            }
            else if (check_domen_1.Text == "Yandex.ru")
            {
                txt_smtp_1.Text = "smtp.yandex.ru";
                txt_port_1.Text = "587";
                check_ssl_1.Checked = true;
            }
            else if (check_domen_1.Text == "Google.com")
            {
                txt_smtp_1.Text = "smtp.gmail.com";
                txt_port_1.Text = "587";
                check_ssl_1.Checked = true;
            }
            else if (check_domen_1.Text == "Yahoo.com")
            {
                txt_smtp_1.Text = "smtp.mail.yahoo.com";
                txt_port_1.Text = "465";
                check_ssl_1.Checked = true;
            }
        }

        private void check_domen_2_SelectedIndexChanged(object sender, EventArgs e) //при выборке заполнять поля стандартными значениями
        {
            if (check_domen_2.Text == "Mail.ru")
            {
                txt_smtp_2.Text = "smtp.mail.ru";
                txt_port_2.Text = "25";
                check_ssl_2.Checked = true;
            }
            else if (check_domen_2.Text == "Yandex.ru")
            {
                txt_smtp_2.Text = "smtp.yandex.ru";
                txt_port_2.Text = "587";
                check_ssl_2.Checked = true;
            }
            else if (check_domen_2.Text == "Google.com")
            {
                txt_smtp_2.Text = "smtp.gmail.com";
                txt_port_2.Text = "587";
                check_ssl_2.Checked = true;
            }
            else if (check_domen_2.Text == "Yahoo.com")
            {
                txt_smtp_2.Text = "smtp.mail.yahoo.com";
                txt_port_2.Text = "465";
                check_ssl_2.Checked = true;
            }
        }

        private void check_domen_3_SelectedIndexChanged(object sender, EventArgs e) //при выборке заполнять поля стандартными значениями
        {
            if (check_domen_3.Text == "Mail.ru")
            {
                txt_smtp_3.Text = "smtp.mail.ru";
                txt_port_3.Text = "25";
                check_ssl_3.Checked = true;
            }
            else if (check_domen_3.Text == "Yandex.ru")
            {
                txt_smtp_3.Text = "smtp.yandex.ru";
                txt_port_3.Text = "587";
                check_ssl_3.Checked = true;
            }
            else if (check_domen_3.Text == "Google.com")
            {
                txt_smtp_3.Text = "smtp.gmail.com";
                txt_port_3.Text = "587";
                check_ssl_3.Checked = true;
            }
            else if (check_domen_3.Text == "Yahoo.com")
            {
                txt_smtp_3.Text = "smtp.mail.yahoo.com";
                txt_port_3.Text = "465";
                check_ssl_3.Checked = true;
            }
        }

        private void check_domen_4_SelectedIndexChanged(object sender, EventArgs e) //при выборке заполнять поля стандартными значениями
        {
            if (check_domen_4.Text == "Mail.ru")
            {
                txt_smtp_4.Text = "smtp.mail.ru";
                txt_port_4.Text = "25";
                check_ssl_4.Checked = true;
            }
            else if (check_domen_4.Text == "Yandex.ru")
            {
                txt_smtp_4.Text = "smtp.yandex.ru";
                txt_port_4.Text = "587";
                check_ssl_4.Checked = true;
            }
            else if (check_domen_4.Text == "Google.com")
            {
                txt_smtp_4.Text = "smtp.gmail.com";
                txt_port_4.Text = "587";
                check_ssl_4.Checked = true;
            }
            else if (check_domen_4.Text == "Yahoo.com")
            {
                txt_smtp_4.Text = "smtp.mail.yahoo.com";
                txt_port_4.Text = "465";
                check_ssl_4.Checked = true;
            }
        }

        private void check_domen_5_SelectedIndexChanged(object sender, EventArgs e) //при выборке заполнять поля стандартными значениями
        {
            if (check_domen_5.Text == "Mail.ru")
            {
                txt_smtp_5.Text = "smtp.mail.ru";
                txt_port_5.Text = "25";
                check_ssl_5.Checked = true;
            }
            else if (check_domen_5.Text == "Yandex.ru")
            {
                txt_smtp_5.Text = "smtp.yandex.ru";
                txt_port_5.Text = "587";
                check_ssl_5.Checked = true;
            }
            else if (check_domen_5.Text == "Google.com")
            {
                txt_smtp_5.Text = "smtp.gmail.com";
                txt_port_5.Text = "587";
                check_ssl_5.Checked = true;
            }
            else if (check_domen_5.Text == "Yahoo.com")
            {
                txt_smtp_5.Text = "smtp.mail.yahoo.com";
                txt_port_5.Text = "465";
                check_ssl_5.Checked = true;
            }
        }
    }
}
