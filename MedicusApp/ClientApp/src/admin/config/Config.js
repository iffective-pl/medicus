import config from './config.json';

const isDev = !process.env.NODE_ENV || process.env.NODE_ENV === 'development';

if(!isDev) {
    if(window.location.hostname === "medicus.iffective.pl") {
        config.prod.url = window.location.protocol + "//" + config.prod.url + window.location.hostname.replace('medicus','');
        config.prod.minio = window.location.protocol + "//" + config.prod.minio + window.location.hostname.replace('medicus','') + "/";
    } else {
        config.prod.url = window.location.protocol + "//" + config.prod.url + window.location.hostname;
        config.prod.minio = window.location.protocol + "//" + config.prod.minio + window.location.hostname + "/";
    }
}

const Config = isDev ? config.dev : config.prod;

export default Config;