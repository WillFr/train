class TrieNode {
    // Initialize your data structure here.
    
    public char value {get;set;}
    public Dictionary<char,TrieNode> children;
        
    public TrieNode(char val){
        this.children = new Dictionary<char,TrieNode>();
        this.value = val;
    }
}

public class Trie {
    private TrieNode root;
    public Trie() {
        root = new TrieNode((char)0);
    }

    // Inserts a word into the trie.
    public void Insert(String word) {
        Insert(word, root,-1);
    }
    
    private void Insert(string word, TrieNode root, int index){
        if(index == word.Length-1){
            if(!root.children.ContainsKey((char)0)){ root.children.Add((char)0, root);}
            return;
        }
        
        TrieNode node;
        if(!root.children.ContainsKey(word[index+1])){ 
            node = new TrieNode(word[index+1]);
            root.children.Add(word[index+1], node);
        }
        else{
            node = root.children[word[index+1]];
        }
        
        Insert(word, node, index+1);
    }

    // Returns if the word is in the trie.
    public bool Search(string word) {
        return Search(word, root, -1);
    }
    
    private bool Search(string word, TrieNode root, int index){
        if(index == word.Length -1 && root.children.ContainsKey((char)0)){
            return true;
        }
        else if(index == word.Length -1 || !root.children.ContainsKey(word[index+1])){
            return false;
        }
        else{
            return Search(word, root.children[word[index+1]], index+1);
        }
    }

    // Returns if there is any word in the trie
    // that starts with the given prefix.
    public bool StartsWith(string word)
    {
        return StartsWith(word, root, -1);
    }
    
    private bool StartsWith(string word, TrieNode root, int index) {
        if(index == word.Length -1){
            return true;
        }
        else if(!root.children.ContainsKey(word[index+1])){
            return false;
        }
        else{
            return StartsWith(word, root.children[word[index+1]], index+1);
        }
    }
}

// Your Trie object will be instantiated and called as such:
// Trie trie = new Trie();
// trie.Insert("somestring");
// trie.Search("key");