using Compare_Folders.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compare_Folders
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		string path1, path2;
		[DllImport("User32.dll")]
		static extern int SetForegroundWindow(IntPtr point);
		struct sfile
		{
			public string filename;
			public string filepath;
			public string subpath;
		}
		List<sfile> files1;
		List<sfile> files2;
		struct compare
		{
			public string subpath;
			public string fullname1;
			public string fullname2;
		}
		List<compare> compareresult;
		List<string> differents;
		private void btnCompare_Click(object sender, EventArgs e)
		{
			compareresult = new List<compare>();
			foreach(sfile file1 in files1)
			{
				try
				{
					bool find = false;
					foreach (sfile file2 in files2)
					{
						try
						{
							if (file1.filename.Equals(file2.filename))
							{
								find = true;
								string text1 = StandardizeFile(System.IO.File.ReadAllText(file1.filepath),false);
								if (checkBox2.Checked) text1 = Standardize2File(text1, true);
								if (checkBox4.Checked) text1 = beautify(text1);
								string text2 = StandardizeFile(System.IO.File.ReadAllText(file2.filepath),false);
								if (checkBox2.Checked) text2 = Standardize2File(text2, true);
								if (checkBox4.Checked) text2 = beautify(text2);
								if (text1  !=  text2)
								{
									compare different = new compare();
									different.subpath = file1.filename;
									different.fullname1 = file1.filepath;
									different.fullname2 = file2.filepath;
									var search = compareresult.Where(s => s.fullname1 == different.fullname1).ToList();
									if(search  !=  null && search.Count == 0) {
											compareresult.Add(different);
									}
								}
							}
						}
					catch { }
					}
					if (!find)
					{
						compare different = new compare();
						different.subpath = "++"+file1.filename;
						different.fullname1 = file1.filepath;
						var search = compareresult.Where(s => s.fullname1 == different.fullname1).ToList();
						if (search  !=  null && search.Count == 0)
						{
							compareresult.Add(different);
						}
					}
				}
			catch { }
			}
			foreach (sfile file2 in files2)
			{
				try
				{
					bool find = false;
					foreach (sfile file1 in files1)
					{
						try
						{
							if (file1.filename.Equals(file2.filename))
							{
								find = true;
								string text1 = StandardizeFile(System.IO.File.ReadAllText(file1.filepath), false);
								if (checkBox2.Checked) text1 = Standardize2File(text1, true);
								if (checkBox4.Checked) text1 = beautify(text1);
								string text2 = StandardizeFile(System.IO.File.ReadAllText(file2.filepath), false);
								if (checkBox2.Checked) text2 = Standardize2File(text2, true);
								if (checkBox4.Checked) text2 = beautify(text2);
								if (text1 != text2)
								{
									compare different = new compare();
									different.subpath = file1.filename;
									different.fullname1 = file1.filepath;
									different.fullname2 = file2.filepath;
									var search = compareresult.Where(s => s.fullname2 == different.fullname2).ToList();
									if (search  !=  null && search.Count == 0)
									{
										compareresult.Add(different);
									}
								}
							}
						}
					catch { }
					}
					if (!find)
					{
						compare different = new compare();
						different.subpath = "--"+file2.filename;
						different.fullname2 = file2.filepath;
						var search = compareresult.Where(s => s.fullname1 == different.fullname1).ToList();
						if (search  !=  null && search.Count == 0)
						{
							compareresult.Add(different);
						}
					}
				}
			catch { }
			}
			listBox3.Items.Clear();
			foreach (compare cmp in compareresult)
			{
				listBox3.Items.Add(cmp.subpath);
			}
		}
		private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<string> paths = new List<string>();
			List<string> contents = new List<string>();
			var search = compareresult.Where(s => s.subpath == listBox3.SelectedItem.ToString()).ToList();
			Process process = new Process();
			int counter = 1;
			lblselectedcompare.Text = "";
			if (search  !=  null && search.Count> 0)
			{
				int num = 0;
				foreach (var item in search)
				{
					string file1 = item.fullname1;
					string file2 = item.fullname2;
					if (!paths.Contains(file1))
					{
						if (file1  !=  null)
						{
							paths.Add(file1);
							contents.Add(System.IO.File.ReadAllText(file1));
						}
					}
					if (!paths.Contains(file2))
					{
						if (file2  !=  null)
						{
							paths.Add(file2);
							contents.Add(System.IO.File.ReadAllText(file2));
						}
					}
				}
				foreach (var item in paths)
				{
					lblselectedcompare.Text += "path"+counter+" "+item.Replace(path1+"\\", "").Replace(path2+"\\", "")+"\n";
					counter++;
				}
			}
		}
		private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			List<string> paths = new List<string>();
			List<string> contents = new List<string>();
			var search = compareresult.Where(s => s.subpath == listBox3.SelectedItem.ToString()).ToList();
			Process process = new Process();
			int counter = 1;
			lblselectedcompare.Text = "";
			if (search  !=  null && search.Count> 0)
			{
				foreach (var item in search)
				{
					string file1 = item.fullname1;
					string file2 = item.fullname2;
					if (!paths.Contains(file1))
					{
						if (file1  !=  null)
						{
							paths.Add(file1);
							contents.Add(System.IO.File.ReadAllText(file1));
						}
					}
					if (!paths.Contains(file2))
					{
						if (file2  !=  null)
						{
							paths.Add(file2);
							contents.Add(System.IO.File.ReadAllText(file2));
						}
					}
				}
				if (paths.Count> 0) {
						Process.Start("notepad++.exe", "\""+paths[0]+"\"");
					lblselectedcompare.Text = "";
					foreach (var item in paths)
					{
						lblselectedcompare.Text += "path"+counter+" "+item.Replace(path1+"\\", "").Replace(path2+"\\", "")+"\n";
						counter++;
					}
				}
				int delay = 500;
				System.Threading.Thread.Sleep(delay); delay = 100;
				System.Windows.Forms.SendKeys.SendWait("^+{W}");
				System.Threading.Thread.Sleep(delay);
				int num = 0;
				for (int i = 0; i <paths.Count; i++)
				{
					if (!checkBox1.Checked)
					{
						Process.Start("notepad++.exe", "\""+paths[i]+"\"");
						System.Threading.Thread.Sleep(delay);
					}else
					{
						num++;
						string textf = System.IO.File.ReadAllText(paths[i]);
						if (checkBox1.Checked) textf = StandardizeFile(textf,false);
						if (checkBox2.Checked) textf = Standardize2File(textf,true);
						if (checkBox4.Checked) textf = beautify(textf);

						System.IO.File.WriteAllText("temp"+num+".c", textf);
						string pth = System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"\\"+"temp"+num+".c";
						Process.Start("notepad++.exe", "\""+pth+"\"");
						System.Threading.Thread.Sleep(delay);
					}
				}
				if(paths.Count == 2)
				{
					System.Threading.Thread.Sleep(100);
					Process p = Process.GetProcessesByName("Notepad++").FirstOrDefault();
					if (p  !=  null)
					{
						IntPtr h = p.MainWindowHandle;
						SetForegroundWindow(h);
					SendKeys.SendWait("^+{C}");
					}
				}
			}
		}
		private void btnopen1_Click(object sender, EventArgs e)
		{
			OpenFileDialog op = new OpenFileDialog();
			op.ValidateNames = false;
			op.CheckFileExists = false;
			op.FileName = "Folder Selection";
			try
			{
				op.InitialDirectory= System.IO.File.ReadAllText("defaultpath1.txt");
			}
			catch { }

			if (op.ShowDialog() == DialogResult.OK)
			{
				path1 = op.FileName;
				DirectoryInfo directory = new DirectoryInfo(path1);
				path1 = directory.Parent.FullName;
				try
				{
					System.IO.File.WriteAllText("defaultpath1.txt", path1);
				}
				catch { }
				

				label1.Text = "Folder:\n--" + path1.Split('\\').Last();
				DirectoryInfo d = new DirectoryInfo(path1); //Assuming Test is your Folder
				files1 = new List<sfile>();
				getfiles(d, files1);
				listBox1.Items.Clear();
				foreach (sfile file in files1)
				{
					listBox1.Items.Add(file.filepath.Replace(path1 + "\\", ""));
				}

			}
		}
		private void btnopen2_Click(object sender, EventArgs e)
		{
			OpenFileDialog op = new OpenFileDialog();
			op.ValidateNames = false;
			op.CheckFileExists = false;
			op.FileName = "Folder Selection";
			try
			{
				op.InitialDirectory = System.IO.File.ReadAllText("defaultpath2.txt");
			}
			catch { }
			if (op.ShowDialog() == DialogResult.OK)
			{
				path1 = op.FileName;
				DirectoryInfo directory = new DirectoryInfo(path1);
				path2 = directory.Parent.FullName;
				System.IO.File.WriteAllText("defaultpath2.txt",path2);
				label2.Text = "Folder:\n--" + path2.Split('\\').Last();
				DirectoryInfo d = new DirectoryInfo(path2); //Assuming Test is your Folder
				files2 = new List<sfile>();
				getfiles(d, files2);
				listBox2.Items.Clear();
				foreach (sfile file in files2)
				{
					listBox2.Items.Add(file.filepath.Replace(path2 + "\\", ""));
				}

			}

			
		}
		private void Form1_Load(object sender, EventArgs e)
		{
		}
		void getfiles(DirectoryInfo directoryInfo, List<sfile> files)
		{
			foreach(DirectoryInfo directoryInfo1 in directoryInfo.GetDirectories())
			{
				getfiles(directoryInfo1,files);
			}
			foreach (string filetype in txtFileTypes.Text.Split(','))
			{
				FileInfo[] Files = directoryInfo.GetFiles(filetype); //Getting Text files
				string str = "";
				foreach (FileInfo file in Files)
				{
					sfile _file = new sfile();
					_file.filename = file.Name;
					_file.filepath = file.FullName;
					files.Add(_file);
				}
			}
		}
		string StandardizeFile(string text1, bool removespace)
		{
			if(removespace) text1 = text1.Replace(" ", "").Replace("\t", "");
			text1 = text1.Replace("\r", "\n");
			while (text1.Contains("\n\n")) text1 = text1.Replace("\n\n", "\n");
			string[] lines1 = text1.Split('\n');
			int numtabs = 0;
			string str1 = "";
			foreach (string line in lines1)
			{
				string s = remove_comments(line);
				
					if (s.Length>0)
					{
						str1 += s + "\n";
					}
				
			}
			return str1;
		}
		string Standardize2File(string text1,bool tabok)
		{

			text1 = text1.Replace("\r", "");
			string[] lines1 = text1.Split('\n');
			int numtabs = 0;
			string str1 = "";
			foreach (string line in lines1)
			{
				string s = remove_comments(standardize(line));

				if (s.Length> 0)
				{
					if (!s.Contains("#include"))
					{
						if (s.Contains("{")) numtabs++;
						if (s.Contains("}")) numtabs--;
						if (numtabs <0) numtabs = 0;
						string stdr;
						if (checkBox3.Checked) stdr = remove_precedence(s);
						else stdr = s;
						//if(tabok) for (int i = 0; i <numtabs; i++) stdr = "\t"+stdr;
						str1 += stdr+"\n";
					}
				}
			}
			return str1;
		}
		bool CompareFiles(string text1, string text2)
		{
			string[] s1 = StandardizeFile(text1, true).Split('\n');
			string[] s2 = StandardizeFile(text2, true).Split('\n');
			if(s1.Length  !=  s2.Length) return false;
			bool result = true;
			for(int i = 0;i<s1.Length;i++)
			{
				if(remove_precedence(s1[i])  !=  remove_precedence(s2[i]))result = false;
			}
			return result;
		}
		string standardize(string s)
		{
			string r = s;
			r = r.Replace("int8u ", "uint8_t ");
			r = r.Replace("int16u ", "uint16_t ");
			r = r.Replace("int32u ", "uint32_t ");
			r = r.Replace("int8s ", "int8_t ");
			r = r.Replace("int16s ", "int16_t ");
			r = r.Replace("int32s ", "int32_t ");
			r = r.Replace("int8u*", "uint8_t*");
			r = r.Replace("int16u*", "uint16_t*");
			r = r.Replace("int32u*", "uint32_t*");
			r = r.Replace("int8s*", "int8_t*");
			r = r.Replace("int16s*", "int16_t*");
			r = r.Replace("int32s*", "int32_t*");
			r = r.Replace("int8u\t", "uint8_t\t");
			r = r.Replace("int16u\t", "uint16_t\t");
			r = r.Replace("int32u\t", "uint32_t\t");
			r = r.Replace("int8s\t", "int8_t\t");
			r = r.Replace("int16s\t", "int16_t\t");
			r = r.Replace("int32s\t", "int32_t\t");
			r = r.Replace("(int8u)", "(uint8_t)");
			r = r.Replace("(int16u)", "(uint16_t)");
			r = r.Replace("(int32u)", "(uint32_t)");
			r = r.Replace("(int8s)", "(int8_t)");
			r = r.Replace("(int16s)", "(int16_t)");
			r = r.Replace("(int32s)", "(int32_t)");
			while (r.Contains("  ")) { r = r.Replace("  ", " "); }
			while (r.Contains("\t\t")) { r = r.Replace("\t\t", "\t"); }
			r.Replace("\t", " ");
			return r.TrimStart().TrimEnd();
		}
		string remove_precedence(string str)
		{
			str = str.Replace(" == ", "##").Replace("  !=  ", "##").Replace("  >=  ", "##").Replace("  <=  ", "##");
			str = str.Replace(" && ", "$$").Replace(" || ", "$$").Replace("&", "$$").Replace("|", "$$");
			str = str.Replace("++", "").Replace("--", "");
			str = str.Replace("-", "%%").Replace("+", "%%").Replace("/", "%%").Replace("*", "%%").Replace("\\", "%%");
			str = str.Replace("##", " ");
			str = str.Replace("$$", " ");
			str = str.Replace("%%", " ");
			str = str.Replace("(", " ");
			str = str.Replace(")", " ");
			while (str.Contains(" ")) str = str.Replace(" ", "");
			return str.Replace("==","");
		}
		string remove_comments(string str)
		{
			if (str.Contains("//"))
			{
				str = str.Replace("//", "Ó");
				str = str.Split('Ó')[0];
			}
			if (str.Contains("/*"))
			{
				int start = 0, finish = 0;
				for (int i = 0; i <str.Length-1; i++) if (str[i] == '/' && str[i+1] == '*') start = i;
				for (int i = start; i <str.Length-1; i++) if (str[i] == '*' && str[i+1] == '/') finish = i+1;
				string comment = "";
				if(finish>start) comment = str.Substring(start, finish-start+1);
				if(comment.Length>0)str = str.Replace(comment, "");
			}
			while (str.Contains("//")) str = remove_comments(str);
			return str;
		}

		struct repstr
		{
			public string key;
			public string value;
		}
		long linenum = 0;
		List<repstr> replaces = new List<repstr>();
		string extract_string(string str)
		{
			linenum++;
			long strnum = 0;
			while (str.Contains("\"") && str.Split('\"').Length > 2)
			{
				strnum++;
				int start = 0, finish = 0;
				for (int i = 0; i < str.Length; i++)
				{
					if (str[i] == '\"')
					{
						start = i;
						break;
					}
				}
				if (start + 1 < str.Length)
				{
					for (int i = start + 1; i < str.Length; i++) if (str[i] == '\"') { finish = i; break; }
					if (finish < str.Length && finish > start)
					{
						string red = "";
						repstr rs = new repstr();
						rs.key = "#rr$" + linenum + "%-" + strnum + "#";
						rs.value = str.Substring(start, finish - start + 1);
						replaces.Add(rs);
						str = str.Substring(0, start) + rs.key + str.Substring(finish + 1);
					}
				}
			}
			return str;
		}

		string beautify(string text)
		{
			replaces = new List<repstr>();
			try
			{
				string str = text.Replace("\r", "");
				string[] lines = str.Split('\n');
				str = "";
				foreach (string line in lines)
				{
					str += line.Trim() + "\n";
				}
				while (str.Contains("\n\n\n")) str = str.Replace("\n\n\n", "\n\n");
				lines = str.Split('\n');

				string rsl = "";
				int tabs = 0;
				bool ifenter = false;
				bool caseenter = false; bool casetabadd = false;
				foreach (string line in lines)
				{
					string s = extract_string(line);

					while (s.Contains("\t\t")) s = s.Replace("\t\t", "\t");
					while (s.Contains("  ")) s = s.Replace("  ", " ");
					while (s.Contains("// ")) s = s.Replace("// ", "//");
					s = s.Trim();
					while (s.Contains("( ")) s = s.Replace("( ", "(");
					while (s.Contains(" )")) s = s.Replace(" )", ")");
					while (s.Contains(" &")) s = s.Replace(" &", "&");
					while (s.Contains("& ")) s = s.Replace("& ", "&");
					while (s.Contains(" |")) s = s.Replace(" |", "|");
					while (s.Contains("| ")) s = s.Replace("| ", "|");
					while (s.Contains(" =")) s = s.Replace(" =", "=");
					while (s.Contains("= ")) s = s.Replace("= ", "=");
					while (s.Contains(" !")) s = s.Replace(" !", "!");
					while (s.Contains("! ")) s = s.Replace("! ", "!");
					while (s.Contains(" ~")) s = s.Replace(" ~", "~");
					while (s.Contains("~ ")) s = s.Replace("~ ", "~");
					while (s.Contains(" +")) s = s.Replace(" +", "+");
					while (s.Contains("+ ")) s = s.Replace("+ ", "+");
					while (s.Contains(" -")) s = s.Replace(" -", "-");
					while (s.Contains("- ")) s = s.Replace("- ", "-");
					while (s.Contains(" >")) s = s.Replace(" >", ">");
					while (s.Contains("> ")) s = s.Replace("> ", ">");
					while (s.Contains("< ")) s = s.Replace("< ", "<");
					while (s.Contains(" <")) s = s.Replace(" <", "<");
					while (s.Contains(" ^")) s = s.Replace(" ^", "^");
					while (s.Contains("^ ")) s = s.Replace("^ ", "^");
					while (s.Contains("% ")) s = s.Replace("% ", "%");
					while (s.Contains(" %")) s = s.Replace(" %", "%");
					while (s.Contains(" ,")) s = s.Replace(" ,", ",");
					while (s.Contains(", ")) s = s.Replace(", ", ",");

					s = s.Replace("===", "%4$3-%");
					while (s.Contains("%4$3-%=")) s = s.Replace("%4$3-%=", "%4$3-%");
					while (s.Contains("=%4$3-%")) s = s.Replace("=%4$3-%", "%4$3-%");



					s = s.Replace("==", "#5$6-#");
					s = s.Replace("!=", "#7$8-#");
					s = s.Replace(">>=", "#j$k-#");
					s = s.Replace(">>", "#k$l-#");
					s = s.Replace("<<=", "#l$m-#");
					s = s.Replace("<<", "#m$n-#");
					s = s.Replace("<=", "#1$2-#");
					s = s.Replace(">=", "#2$3-#");
					s = s.Replace("->", "#r$3-#");
					s = s.Replace("|=", "#a$b-#");
					s = s.Replace("&=", "#c$d-#");
					s = s.Replace("/=", "#d$e-#");
					s = s.Replace("*=", "#e$f-#");
					s = s.Replace("+=", "#f$g-#");
					s = s.Replace("-=", "#g$h-#");
					s = s.Replace("%=", "#h$i-#");
					s = s.Replace("^=", "#r$1-#");
					s = s.Replace("=>", "#r$4-#");
					s = s.Replace(",", "#r$5-#");
					s = s.Replace("\\=", "#i$j-#");


					s = s.Replace("&&", " && ");
					s = s.Replace("||", " || ");
					s = s.Replace("=", " = ");
					s = s.Replace("^", " ^ ");

					s = s.Replace("#5$6-#", " == ");
					s = s.Replace("%4$3-%", "===");
					s = s.Replace("#7$8-#", " != ");
					s = s.Replace("!=", " != ");
					s = s.Replace("#1$2-#", " <= ");

					s = s.Replace("#2$3-#", " >= ");
					s = s.Replace("#a$b-#", " |= ");
					s = s.Replace("#c$d-#", " &= ");
					s = s.Replace("#d$e-#", "/= ");
					s = s.Replace("#e$f-#", " *= ");
					s = s.Replace("#f$g-#", " += ");
					s = s.Replace("#g$h-#", " -= ");
					//s = s.Replace("#3$4#","<=>" );
					s = s.Replace("<=", " <= ");
					s = s.Replace(">=", " >= ");
					//s = s.Replace("<=>"  ," <=> ");
					s = s.Replace("#j$k-#", " >>= ");
					s = s.Replace("#k$l-#", " >> ");
					s = s.Replace("#l$m-#", " <<= ");
					s = s.Replace("#m$n-#", " << ");
					s = s.Replace("#h$i-#", " %= ");
					s = s.Replace("#r$1-#", " ^= ");
					s = s.Replace("#r$3-#", " -> ");
					s = s.Replace("#r$4-#", " => ");
					s = s.Replace("#r$5-#", ", ");


					s = s.Replace("#i$j-#", " \\= ");

					if (s.Length == 0 && tabs > 0) continue;

					if (s.Contains("}")) tabs--;
					if (tabs < -1) tabs = -1;

					if (ifenter && s.Contains("{")) ifenter = false;
					if (caseenter && (s.StartsWith("case ") || s.StartsWith("default:") || s.StartsWith("default :") || s.StartsWith("break;") || s.StartsWith("break ;"))) { caseenter = false; tabs--; }
					if (ifenter) s = "\t" + s;
					if (s.StartsWith("if(") || s.StartsWith("if ") || s.StartsWith("else ") || s.StartsWith("else {")) ifenter = true;
					if (s.StartsWith("case ") && s.Contains(":")) { caseenter = true; casetabadd = false; }
					if (s.StartsWith("default") && s.Contains(":")) { caseenter = true; casetabadd = false; }
					if (ifenter && s.Contains(";")) ifenter = false;

					for (int i = 0; i < tabs; i++) s = "\t" + s;
					if (caseenter && !casetabadd) { casetabadd = true; tabs++; }
					if (s.Contains("{")) tabs++;
					rsl += s + "\n";
					if (s.Contains("}") && tabs == 0) rsl += "\n";
				}

				foreach (repstr rep in replaces)
				{
					rsl = rsl.Replace(rep.key, rep.value);
				}
				return rsl;


			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}



