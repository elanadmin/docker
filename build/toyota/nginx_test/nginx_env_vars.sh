#!/usr/bin/env sh

###-->This Script Interpolates Container Environment Variables, defined in nginx.conf<--###

set -eu

envsubst "$(env | awk -F = '{printf " $%s", $1}')" < /tmp/nginx.conf > /tmp/nginx.conf.rendered
mv /tmp/nginx.conf.rendered /etc/nginx/nginx.conf
rm /tmp/nginx.conf

exec "$@"

########################################-->END<--##########################################
