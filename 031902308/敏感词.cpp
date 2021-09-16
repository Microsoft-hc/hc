#include <iostream>
#include <fstream>
#include <stdlib.h>
using namespace std;
class check_file{
public:
	check_file();//打开原文件，建立存敏感词汇的文件
	~check_file();//关闭原文件、敏感词汇文件
	void check_files();//读原文件，并将敏感词汇写入敏感词汇文件
	void in_file();//声明函数in_file的原型，输出原文件内容
	void outfile();//声明函数outfile的原型，输出敏感词汇文件内容
private:
	fstream inf;//用fstream类定义输入输出流对象，用来连接原文件
	fstream outf;//用fstream类定义输入输出流对象，用来连接敏感词汇文件
	char file1[10];//用来存放原文件名字
	char file2[10];//用来存放目的文件名字
};
check_file::check_file()
{
	cout << "请输入要检测文件名字:";
	cin >> file1;
	inf.open(file1, ios::in | ios::_Nocreate);
	//打开一个原文件,如文件不存在,则打开失败;
	//ios::nocreate不建立文件，所以文件不存在时打开失败
	if (!inf)
	{
		cout << "不能打开该文件:" << file1 << endl;
		abort();
	}
	cout << "请输入将要存入敏感词汇的文件名：";
	cin >> file2;
	outf.open(file2, ios::in| ios::_Noreplace);
	//打开敏感词汇的文件，若文件已存在，则打开失败
	//ios::noreplace不覆盖文件，所以打开文件时如果文件存在失败
	if (!outf)
	{
		cout << "不能打开该文件" << file2 << endl;
		abort();
	}
}
check_file::~check_file()
//关闭原文件和敏感词汇文件
{
	inf.close();
	outf.close();
}
void check_file::check_files()
//在原文件中检测敏感词汇，并将其写入敏感词汇文件中
{
	char ch;
	int count = 0;//用于统计敏感词的个数
	inf.seekg(0);//将读指针移到文件开头位置
	inf.get(ch);//获取字符
	while (!inf.eof())
	{
		if (ch == 'a')//检测敏感词汇的部分
		{
			inf.get(ch);
			if (ch == 's')
			{
				inf.get(ch);
				if (ch == 'k')
				{
					char* c;//定义字符指针用来存敏感词汇"ask"
					int i = 0;
					c = "ask";
					for (i = 0; i < 3; i++)//用于输出敏感词汇
						outf.put(c[i]);
					outf.put('\n');//控制换行
					count++;
					inf.get(ch);
				}
				else inf.get(ch);
			}
			else inf.get(ch);
		}
		else inf.get(ch);

	}
	cout << "敏感词汇有" << count << "个" << endl;
}
void check_file::in_file()
//定义函数in_file，输出原文件内容
{
	char ch;
	inf.close();
	inf.open(file1, ios::in);
	inf.get(ch);
	while (!inf.eof())
	{
		cout << ch;
		inf.get(ch);
	}
	cout << endl;
}
void check_file::outfile()
//定义函数outfile,输出敏感词汇文件的内容
{
	char ch;
	outf.seekg(0);  //将文件指针定位在文件的首位
	outf.get(ch);
	while (!outf.eof())
	{
		cout << ch;
		outf.get(ch);
	}
	cout << endl;
}
int main()
{
	check_file cf;
	cf.check_files();
	cout << "原文件内容是：" << endl;
	cf.in_file();
	cout << "sentive.txt内容是：" << endl;
	cf.outfile();
	return 0;
}









