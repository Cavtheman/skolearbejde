# ~/.bashrc: executed by bash(1) for non-login shells.
# see /usr/share/doc/bash/examples/startup-files (in the package bash-doc)
# for examples

# If not running interactively, don't do anything
case $- in
    *i*) ;;
      *) return;;
esac



##############################################################################################################
# My Stuff

py() { python3.6 "$@"; }

cdd() { cd "$@" && ls --color=auto; }

# Staffeli download submissions for PoP
retd () {
    python3 ~/staffeli_nt/staffeli_nt/download.py 51737 "$1"template.yml "$1" --select-section
}

resub () {
    python3 ~/staffeli_nt/staffeli_nt/download.py 51737 "$1"template.yml "$1"resub --resub --select-ta "$1"_ta_list.yml
}

retdta () {
    python3 ~/staffeli_nt/staffeli_nt/download.py 51737 "$1"template.yml "$1" --select-ta "$1"_ta_list.yml
}

# Staffeli upload grades for PoP
retu () {
    python3 ~/staffeli_nt/staffeli_nt/upload.py "$1"template.yml "$1" "${@:2}"
}

retur () {
    python3 ~/staffeli_nt/staffeli_nt/upload.py "$1"template.yml "$1"resub "${@:2}"
}

# For grading PoP assignments
ret () {
    zipf="$1"
    unzip "$1"
    len=${#zip}-4
    cd ${1:0:len}
    cat README.txt
    echo ""
    ls --color=auto
    #unzip "$1" -d ~/Downloads/pop/
    #cat ~/Downloads/pop/README.txt
    #echo ""
    #cdd ~/Downloads/pop/
}

fin () {
    rm -r ~/Downloads/pop/"$1"
    rm -f ~/Downloads/pop/*.exe ~/Downloads/pop/*.dll ~/Downloads/pop/README.txt
    rm -rf ~/Downloads/pop/__MACOSX
    cd ~/Downloads
}

mappe() {
    mv "$1"/* ./
    rmdir "$1"
    ls --color=auto
}

rider() {
    ~/Programs/rider/bin/./rider.sh &
}
fsh() {
    fsx="$1"
    len=${#fsx}-4
    fsharpc ${1:0:len}.fsx
    mono ${1:0:len}.exe "${@:2}"
}
fdll() {
    fsharpc -a "$@"
}
dfsh() {
    fsx="$2"
    len=${#fsx}-4
    fsharpc -r "$1" ${2:0:len}.fsx
    mono ${2:0:len}.exe "${@:3}"
}

get() {
    sudo apt-get install $@
}

upd() {
    sudo apt-get -qq update
    sudo apt-get dist-upgrade
    sudo apt-get autoremove
}

latex() {
    pdflatex --shell-escape "$1"
}

lpdf() {
    bibtex master.aux
    pdflatex --shell-escape master.tex
    pdflatex --shell-escape master.tex > /dev/null 2>&1
    evince master.pdf &
}

ghci(){
    stack exec ghci -- -W "$1"
}

discord(){
    /snap/bin/./discord > /dev/null &
}

onlineTA(){
    #cp -r "$1" code
    stack onlineta.hs "$1" code > testresults.txt
    #rm -r code
}

popta(){
    curl -F handin=@code.zip https://pop.incorrectness.dk/grade/assignment"$1"
}

imgfsh(){
    fsx="$1"
    len=${#fsx}-4
    #fsharpc ${1:0:len}.fsx
    fsharpc --nologo -I /usr/lib/cli/gtk-sharp-2.0 -I /usr/lib/cli/gdk-sharp-2.0 -I /usr/lib/cli/glib-sharp-2.0 -I /usr/lib/cli/gtk-dotnet-2.0 -I /usr/lib/cli/atk-sharp-2.0 -r gdk-sharp.dll -r gtk-sharp.dll -r img_util.dll ${1:0:len}.fsx
    mono ${1:0:len}.exe "${@:2}"
}
##############################################################################################################
# don't put duplicate lines or lines starting with space in the history.
# See bash(1) for more options
HISTCONTROL=ignoreboth

# append to the history file, don't overwrite it
shopt -s histappend

# for setting history length see HISTSIZE and HISTFILESIZE in bash(1)
HISTSIZE=1000
HISTFILESIZE=2000

# check the window size after each command and, if necessary,
# update the values of LINES and COLUMNS.
shopt -s checkwinsize

# If set, the pattern "**" used in a pathname expansion context will
# match all files and zero or more directories and subdirectories.
#shopt -s globstar

# make less more friendly for non-text input files, see lesspipe(1)
[ -x /usr/bin/lesspipe ] && eval "$(SHELL=/bin/sh lesspipe)"

# set variable identifying the chroot you work in (used in the prompt below)
if [ -z "${debian_chroot:-}" ] && [ -r /etc/debian_chroot ]; then
    debian_chroot=$(cat /etc/debian_chroot)
fi

# set a fancy prompt (non-color, unless we know we "want" color)
case "$TERM" in
    xterm-color|*-256color) color_prompt=yes;;
esac

# uncomment for a colored prompt, if the terminal has the capability; turned
# off by default to not distract the user: the focus in a terminal window
# should be on the output of commands, not on the prompt
#force_color_prompt=yes

if [ -n "$force_color_prompt" ]; then
    if [ -x /usr/bin/tput ] && tput setaf 1 >&/dev/null; then
	# We have color support; assume it's compliant with Ecma-48
	# (ISO/IEC-6429). (Lack of such support is extremely rare, and such
	# a case would tend to support setf rather than setaf.)
	color_prompt=yes
    else
	color_prompt=
    fi
fi

if [ "$color_prompt" = yes ]; then
    PS1='${debian_chroot:+($debian_chroot)}\[\033[01;32m\]\u@\h\[\033[00m\]:\[\033[01;34m\]\W\[\033[00m\]\$ '
else
    PS1='${debian_chroot:+($debian_chroot)}\u@\h:\W\$ '
fi
unset color_prompt force_color_prompt

# If this is an xterm set the title to user@host:dir
case "$TERM" in
xterm*|rxvt*)
    PS1="\[\e]0;${debian_chroot:+($debian_chroot)}\u@\h: \w\a\]$PS1"
    ;;
*)
    ;;
esac

# enable color support of ls and also add handy aliases
if [ -x /usr/bin/dircolors ]; then
    test -r ~/.dircolors && eval "$(dircolors -b ~/.dircolors)" || eval "$(dircolors -b)"
    alias ls='ls --color=auto'
    #alias dir='dir --color=auto'
    #alias vdir='vdir --color=auto'

    alias grep='grep --color=auto'
    alias fgrep='fgrep --color=auto'
    alias egrep='egrep --color=auto'
fi

# colored GCC warnings and errors
#export GCC_COLORS='error=01;31:warning=01;35:note=01;36:caret=01;32:locus=01:quote=01'

# some more ls aliases
alias ll='ls -alF'
alias la='ls -A'
alias l='ls -CF'

# Add an "alert" alias for long running commands.  Use like so:
#   sleep 10; alert
alias alert='notify-send --urgency=low -i "$([ $? = 0 ] && echo terminal || echo error)" "$(history|tail -n1|sed -e '\''s/^\s*[0-9]\+\s*//;s/[;&|]\s*alert$//'\'')"'

# Alias definitions.
# You may want to put all your additions into a separate file like
# ~/.bash_aliases, instead of adding them here directly.
# See /usr/share/doc/bash-doc/examples in the bash-doc package.

if [ -f ~/.bash_aliases ]; then
    . ~/.bash_aliases
fi

# enable programmable completion features (you don't need to enable
# this, if it's already enabled in /etc/bash.bashrc and /etc/profile
# sources /etc/bash.bashrc).
if ! shopt -oq posix; then
  if [ -f /usr/share/bash-completion/bash_completion ]; then
    . /usr/share/bash-completion/bash_completion
  elif [ -f /etc/bash_completion ]; then
    . /etc/bash_completion
  fi
fi
