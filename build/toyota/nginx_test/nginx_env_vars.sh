#!/usr/bin/env sh

###-->This Script Interpolates Container Environment Variables, defined in nginx.conf<--###

set -eu

cp -rp /etc/nginx/conf.d/default.conf /tmp/default.conf
cp -rp /usr/share/nginx/html/index.html /tmp/index.html
envsubst "$(env | awk -F = '{printf " $%s", $1}')" < /tmp/default.conf > /tmp/default.conf.rendered
envsubst "$(env | awk -F = '{printf " $%s", $1}')" < /tmp/index.html > /tmp/index.html.rendered
mv /tmp/default.conf.rendered /etc/nginx/conf.d/default.conf
mv /tmp/index.html.rendered /usr/share/nginx/html/index.html
rm /tmp/default.conf /tmp/index.html

exec "$@"

########################################-->END<--##########################################
