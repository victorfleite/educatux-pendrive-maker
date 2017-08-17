Educatux Game Container
===============================

Este projeto tem como objetivo gamificar atividades educacionais.


ESTRUTURA DE DIRETORIOS
-------------------

```
app/
    loading/             possui as funcionalidades do apresentar retornar ao usuário o status do download.
    util/				 serviços que podem ser compartilhados e usados por todos os módulos
assets/					 todos os javascripts externos (vendors), imagens, arquivos de configuração do jogos, fonts e css.
deploy/ 				 pasta de saída do arquivo de exportação da aplicação
dist/					 pasta de saída usada pelo automatizador de tarefas para unificar os arquivos
node_modules/			 todos os módulos npm instalados para serem usados com o nodejs
views/					 todos os arquivos de tamplate de html usados pelos módulos
Gulpfile.js				 arquivo de configuração do automatizador de tarefas
bower.json  			 arquivo de configuração do bower (controlador de bibliotecas javascript)
package.json 			 arquivo de configuração da aplicação
```

COMO BAIXAR A APLICAÇÃO DO GIT 
-------------------

```
Para instalar o GIT na máquina digite: sudo apt-get install git

1. $ mkdir /opt/educatux-downloader
2. $ cd /opt/educatux-downloader
3. $ git init
4. $ git remote add gitlab http://200.130.106.13/root/educatux-downloader.git
5. $ git fetch gitlab
6. $ git pull gitlab master
```

COMO INICIALIZAR A APLICAÇÃO
-------------------

```
Acesse a pasta $ cd /opt/educatux-downloader
Linux 32 bits: $ sh init-ia32.sh &
Linux 64 bits: $ sh init-ia64.sh &
Antes de rodar, deverá ser inicializado o gulp (Leia o tópico PARA DESENVOLVEDOR)
```

PARA DESENVOLVEDOR (IMPORTANTE)
-------------------
Quando inicializado, sempre que modificar algum arquivo, o gulp (automatizador de tarefas) estará escutando para unificar os arquivos js em um só arquivo (/dist/dist.js)
e gerar o binário na raiz da aplicação (dist.bin).

```
No console, para inicializar o gulp:
1. Acesse $ cd /opt/educatux-downloader
2. Atualize o repositorio de pocotes: $ sudo apt-get update
3. Instale o Nodejs e gerenciador de pacotes do node npm, caso não tenha instalado: $ sudo apt-get install -y nodejs npm
4. Instale: $ sudo apt-get install -y nodejs-legacy
5. Instale o gerenciador de pacotes javascript bower e o gerenciador de tarefas gulp: $ sudo npm install --global bower gulp
6. Inicialize o automatizador de tarefas: $ sudo gulp &
Para ajuda: $ gulp help

```