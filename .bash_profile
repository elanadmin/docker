# .bash_profile
R='\033[0;31m';
Y='\033[0;33m';
G='\033[0;32m';
N='\033[m';

# Get the aliases and functions
if [ -f ~/.bashrc ]; then
	. ~/.bashrc
fi

# User specific environment and startup programs

PATH=/root/bin:$PATH:$HOME/.local/bin:$HOME/bin

export PATH

source ~/.motd

echo -e "${Y}Please Run /root/bin/elan_docker_login to connect to docker registry ..\n${N}"
