using System;

class BinarySearchTree
{
    class Node
    {
        public int data;
        public Node left, right;

        public Node(int value)
        {
            data = value;
            left = right = null;
        }
    }

    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    // Метод добавления нового узла в дерево
    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    private Node InsertRec(Node root, int key)
    {
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        if (key < root.data)
            root.left = InsertRec(root.left, key);
        else if (key > root.data)
            root.right = InsertRec(root.right, key);

        return root;
    }

    // Метод удаления узла по ключевому значению
    public void Delete(int key)
    {
        root = DeleteRec(root, key);
    }

    private Node DeleteRec(Node root, int key)
    {
        if (root == null)
            return root;

        if (key < root.data)
            root.left = DeleteRec(root.left, key);
        else if (key > root.data)
            root.right = DeleteRec(root.right, key);
        else
        {
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;

            root.data = MinValue(root.right);
            root.right = DeleteRec(root.right, root.data);
        }

        return root;
    }

    private int MinValue(Node root)
    {
        int minv = root.data;
        while (root.left != null)
        {
            minv = root.left.data;
            root = root.left;
        }
        return minv;
    }

    // Метод вычисления глубины дерева
    public int Depth()
    {
        return DepthRec(root);
    }

    private int DepthRec(Node root)
    {
        if (root == null)
            return 0;

        int leftDepth = DepthRec(root.left);
        int rightDepth = DepthRec(root.right);

        return 1 + Math.Max(leftDepth, rightDepth);
    }

    // Дополнительные методы для работы с деревом могут быть добавлены по аналогии

    // Методы для взаимодействия с консолью
    public void PrintTree()
    {
        Console.WriteLine("Дерево:");
        PrintTreeRec(root);
    }

    private void PrintTreeRec(Node root)
    {
        if (root != null)
        {
            PrintTreeRec(root.left);
            Console.Write(root.data + " ");
            PrintTreeRec(root.right);
        }
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();

        Console.WriteLine("Введите элементы для добавления в бинарное дерево (или 'q' для выхода):");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "q")
                break;

            if (int.TryParse(input, out int value))
                bst.Insert(value);
            else
                Console.WriteLine("Введите корректное число или 'q' для выхода.");
        }

        bst.PrintTree();

        Console.WriteLine("Глубина дерева: " + bst.Depth());

        // Пример использования других методов класса BinarySearchTree
        // bst.Delete(5);
        // bst.PrintTree();
        // Console.WriteLine("Глубина дерева после удаления: " + bst.Depth());

        // Добавить метод для объединения двух деревьев или вычисления подобия двух деревьев 
        // Добавить метод для выявления подобия двух деревьев
    }
}


