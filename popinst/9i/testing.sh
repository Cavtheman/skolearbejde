fsharpc -a src/readNWrite.fs

fsharpc -r readNWrite.dll src/cat.fsx
mono cat.exe
mono cat.exe nonexistent
mono cat.exe src/cat.fsx
mono cat.exe src/cat.fsx src/tac.fsx

fsharpc -r readNWrite.dll src/tac.fsx
mono tac.exe
mono tac.exe nonexistent
mono tac.exe src/cat.fsx
mono tac.exe src/cat.fsx src/tac.fsx

fsharpc src/countLinks.fsx
mono countLinks.exe http://fsharp.org
mono countLinks.exe http://google.com
mono countLinks.exe whatever
