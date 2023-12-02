mkdir -p .bin/
rm -rf tla-bin
git clone https://github.com/pmer/tla-bin.git
cd tla-bin/
ls
./download_or_update_tla.sh
cd ..
cp tla-bin/bin/* .bin/
export PATH=$PATH:.bin
rm -rf tla-bin
