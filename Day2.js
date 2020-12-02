let entries = document.querySelector("pre").innerText.split(/^/m);
let matchCount = 0;
entries.forEach((entry) => {
    let info = entry.split(" ");
    let posOne = info[0].split("-")[0];
    let posTwo = info[0].split("-")[1];
    let character = info[1].split(":")[0];
    let passPhrase = info[2];
    let passPhraseArray = passPhrase.split('');
    
    if ((passPhraseArray[posOne-1] === character && passPhraseArray[posTwo-1] !== character)
        || (passPhraseArray[posOne-1] !== character && passPhraseArray[posTwo-1] === character))
    {
        matchCount++;
    }        
});
