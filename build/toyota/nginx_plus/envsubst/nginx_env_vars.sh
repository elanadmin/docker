#!/usr/bin/env sh

###-->This Script Interpolates Container Environment Variables, defined in nginx.conf<--###

set -eu

cp -rp /etc/nginx/nginx.conf /tmp/nginx.conf
cp -rp /usr/share/nginx/html/index.html /tmp/index.html
envsubst "$(env | awk -F = '{printf " $%s", $1}')" < /tmp/nginx.conf > /tmp/nginx.conf.rendered
envsubst "$(env | awk -F = '{printf " $%s", $1}')" < /tmp/index.html > /tmp/index.html.rendered
mv /tmp/nginx.conf.rendered /etc/nginx/nginx.conf
mv /tmp/index.html.rendered /usr/share/nginx/html/index.html
rm /tmp/nginx.conf /tmp/index.html

exec "$@"

########################################-->END<--##########################################
