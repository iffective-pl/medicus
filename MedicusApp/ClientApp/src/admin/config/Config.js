import dotenv from 'dotenv';
import config from './config.json';

const env = dotenv.config();

function cfg() {
    console.log(env)
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