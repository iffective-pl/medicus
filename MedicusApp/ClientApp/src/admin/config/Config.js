import config from './config.json';

function cfg() {
    switch(process.env.NODE_ENV) {
        default:
        case "dev":
            return config.Dev
        case "preprod":
            return config.Preprod
        case "prod":
            return config.Production
    }
}

const Config = cfg();

export default Config;