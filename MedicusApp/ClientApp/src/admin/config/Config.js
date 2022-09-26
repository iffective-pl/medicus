import config from './config.json';

function cfg() {
    switch(process.env.NODE_ENV) {
        default:
        case "Development":
            return config.Development
        case "Preprod":
            return config.Preprod
        case "Production":
            return config.Production
    }
}

const Config = cfg();

export default Config;