using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class II
{
    public int coordinateX;
    public int coordinateY;

    public int temp;// �����������
    public int maxTemp;// ����������� ������ ��� ����
    public int minTemp;// ����������� ������ ��� ������

    public int satiety;// �������
    public int maxSatiety;// ������������ ���������� �������

    public int mindDeep;

    public string condition;
    //energy = Mathf.Round(Random.Range(0f, 20f)) / 2;
    //satiety = Mathf.Round(Random.Range(0f, 20f)) / 2;
    //mindDeep = 1;
    public void MoveRight()
    {
        WorldManager worldManager = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<WorldManager>();
        coordinateX++;
        if (coordinateX >= worldManager.width)
        {
            coordinateX--;
        }
    }
    public void MoveLeft()
    {
        WorldManager worldManager = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<WorldManager>();
        coordinateX--;
        if (coordinateX < 0)
        {
            coordinateX++;
        }
    }
    public void MoveUp()
    {
        WorldManager worldManager = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<WorldManager>();
        coordinateY++;
        if (coordinateY >= worldManager.height)
        {
            coordinateY--;
        }
    }
    public void MoveDown()
    {
        WorldManager worldManager = GameObject.FindGameObjectWithTag("WorldManager").GetComponent<WorldManager>();
        coordinateY--;
        if (coordinateY < 0)
        {
            coordinateY++;
        }
    }
    public void Stay()
    {

    }
    public void GetCondition()
    {
        if (satiety <= maxSatiety / 2)
        {
            if (temp <= maxTemp / 3)
            {
                condition = "�������";
            }
            else if (temp > maxTemp - maxTemp / 3)
            {
                condition = "�����";
            }
            else
            {
                condition = "����������";
            }
        }
        else
        {
            if (temp <= maxTemp / 3)
            {
                condition = "����� � �������";
            }
            else if (temp > maxTemp - maxTemp / 3)
            {
                condition = "����� � �����";
            }
            else
            {
                condition = "�����";
            }
        }
    }
    public abstract void ChooseMove(World world);
}
public class RandomII : II
{
    public RandomII(int importedX, int importedY, int importedMinTemp, int importedMaxTemp, int importedMaxSatiety)
    {
        coordinateX = importedX;
        coordinateY = importedY;

        temp = (importedMaxTemp - importedMinTemp) / 2;
        maxTemp = importedMaxTemp;
        minTemp = importedMinTemp;

        satiety = importedMaxSatiety / 2;
        maxSatiety = importedMaxSatiety;
        mindDeep = 0;
        GetCondition();
    }
    public void RandomMove()
    {
        int i = Random.Range(0, 5);
        switch (i)
        {
            case 0:
                Stay();
                break;
            case 1:
                MoveRight();
                break;
            case 2:
                MoveLeft();
                break;
            case 3:
                MoveUp();
                break;
            case 4:
                MoveDown();
                break;
        }
    }
    public override void ChooseMove(World world)
    {

    }
}
public class BeginnerII : II
{
    public BeginnerII(int importedX, int importedY, int importedMinTemp, int importedMaxTemp, int importedMaxSatiety)
    {
        coordinateX = importedX;
        coordinateY = importedY;

        temp = (importedMaxTemp - importedMinTemp) / 2;
        maxTemp = importedMaxTemp;
        minTemp = importedMinTemp;

        satiety = importedMaxSatiety / 2;
        maxSatiety = importedMaxSatiety;
        mindDeep = 1;
    }
    public override void ChooseMove(World world)
    {

    }
}
public class MasterII : II
{
    public override void ChooseMove(World world)
    {

    }
}