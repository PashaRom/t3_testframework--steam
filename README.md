# t3_testframework--steam

   В файле testconfig.json необходимо указать:
   browsers:<вид браузера>:pathToDriver - путь к webdriver
   browsers:<вид браузера>:isActive - указывает, в каком браузере будет производиться тестирование
   browsers:<вид браузера>:options:implicitWait - время задержки в секундах
   localization:isActive - на какой языковой версии будет проводиться тестирование
   testingUrl - адрес тестируемого web ресурса
   pathDownload - директория для хранения скачиваемых файлов
   checkingDownloadFile:loopCheking - количество проверочных итераций для проверки скачиваемости файла
   checkingDownloadFile:interval - временной интервал между итераций в миллисекундах
   checkingDownloadFile:size - размер скачиваемого файла
   