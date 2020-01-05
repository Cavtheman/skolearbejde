#
# ~/.bashrc
#

# If not running interactively, don't do anything
[[ $- != *i* ]] && return

alias ls='ls --color=auto'
alias usb="sudo usbmuxd -u -U usbmux"
alias xdg="xdg-open"
alias bashrc="xdg ~/.bashrc"
alias upd="sudo pacman -Syu"
alias updsys="sudo pacman -Syyuu"
alias get="sudo pacman -S"

alias gst="git status"
alias gpl="git pull"
alias gps="git push"
alias gad="git add"
alias gcm='function __gcm() { git commit -am "$*"; unset -f __gcm; }; __gcm'
alias ftb="java -jar ~/games/ftb_launcher.jar"

alias home="cd ~/"
cdd() { cd "$@" && ls; }
alias ..="cd .."
alias ...="cd ../.."
alias ....="cd ../../.."

alias compsys="cd ~/skolearbejde/CompSys/compsys/"
alias datsci="cd ~/skolearbejde/datsci/"
alias masd="cd ~/skolearbejde/MASD/"
alias mad="cd ~/skolearbejde/mad/"
alias ad="cd ~/skolearbejde/AD/"
alias rad="cd ~/skolearbejde/rad/"
alias rex="cd ~/skolearbejde/REX/"
alias pop="cd ~/skolearbejde/popinst/"
alias numint="cd ~/skolearbejde/numintro/"
alias nano="cd ~/skolearbejde/nanoneedles/"
alias rebs="cd ~/skolearbejde/rebs/"
alias skole="cd ~/skolearbejde/"
alias down="cd ~/Downloads"
alias books="cd ~/skolebøger/"
alias dnd="cd ~/dnd/Books/"
alias latex="sulatex master.tex && evince master.pdf"

# For grading PoP assignments
ret () {
    unzip "$1" -d ~/Downloads/pop/
    cat ~/Downloads/pop/README.txt
    echo ""
    cdd ~/Downloads/pop/
}
# alias fin="rm -r src/ && rm README.txt && cd .."
fin () {
    rm -r ~/Downloads/pop/"$1"
    rm -f ~/Downloads/pop/*.exe ~/Downloads/pop/*.dll ~/Downloads/pop/README.txt
    rm -rf ~/Downloads/pop/__MACOSX
    cd ~/Downloads
}

# alias mappe="mv * ../ && cd .. && ls tex/ && ls src/"
mappe() {
    mv "$1"/* ./
    rmdir "$1"
    ls
}
alias fdll="fsharpc -a"

rider() {
    ~/rider/bin/./rider.sh &
}
fsh() {
    fsharpc "$1".fsx
    mono "$1".exe "${@:2}"
}
dfsh() {
    fsharpc -r "$1" "$2".fsx
    mono "$2".exe "${@:3}"
}

PS1='[\u@\h \W]\$ '

/usr/bin/setxkbmap -option "ctrl:swapcaps"
# >>> BEGIN ADDED BY CNCHI INSTALLER
BROWSER=/usr/bin/chromium
EDITOR=/usr/bin/nano
# <<< END ADDED BY CNCHI INSTALLER
