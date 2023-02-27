const axios = require("axios");
const Constants = require("../constants/constants");

const gitRequest = async () => {
    const { data } = await axios.get(Constants.URL, { headers: { "Authorization": process.env.TOKEN } });
    const dataFilter = data.filter(item => item.language === Constants.LANGUAGE).slice(Constants.MIN, Constants.MAX);
    return dataFilter.map(item => ({
        name: item.full_name,
        description: item.description,
        image: item.owner.avatar_url
    }));
}

module.exports = gitRequest;
