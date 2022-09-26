import config from './config.json';

function cfg() {
    switch(process.env.NODE_ENV) {
        default:
        case "dev":
            return config.dev
        case "preprod":
            return config.preprod
        case "prod":
            return config.prod
    }
}

const Config = cfg();

export default Config;