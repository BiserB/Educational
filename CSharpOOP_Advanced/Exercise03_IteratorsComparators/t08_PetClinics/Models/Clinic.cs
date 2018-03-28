
using System;
using System.Collections.Generic;
using System.Linq;

public class Clinic
{    
    private Dictionary<int, Pet> rooms;

    public Clinic(string name, int rooms)
    {
        Name = name;
        CreateRooms(rooms);
    }

    public string Name { get; }    

    
    public Dictionary<int, Pet> Rooms
    {
        get { return rooms; }
        private set { rooms = value; }
    }

    private void CreateRooms(int rooms)
    {
        if (rooms % 2 == 0 || rooms <= 0)
        {
            throw new InvalidOperationException("Invalid operation");
        }
        Rooms = new Dictionary<int, Pet>();
        for (int i = 1; i <= rooms; i++)
        {
            Rooms[i] = null;
        }
    }

    public bool Accommodate(Pet pet)
    {
        int roomNumber = (Rooms.Count / 2) + 1;
        int attempt = 1;

        while (ValidateNumber(roomNumber))
        {
            if (Rooms[roomNumber] == null)
            {
                Rooms[roomNumber] = pet;
                return true;
            }
            roomNumber = roomNumber - attempt;
            attempt++;

            if (!ValidateNumber(roomNumber))
            {
                break;
            }

            if (Rooms[roomNumber] == null)
            {
                Rooms[roomNumber] = pet;
                return true;
            }           
            roomNumber = roomNumber + attempt;
            attempt++;
        }
        return false;
    }

    private bool ValidateNumber(int roomNumber)
    {
        return roomNumber > 0 && roomNumber <= Rooms.Count;
    }

    public bool ReleasePet()
    {
        int roomNumber = (Rooms.Count / 2) + 1;

        for (int i = roomNumber; i <= Rooms.Count; i++)
        {
            if (ValidateNumber(i) && Rooms[i] != null)
            {
                Rooms[i] = null;
                return true;
            }
        }

        for (int i = roomNumber - 1; i > 0; i--)
        {
            if (ValidateNumber(i) && Rooms[i] != null)
            {
                Rooms[i] = null;
                return true;
            }
        }
        return false;
    }

    public string PrintAll()
    {
        string result = "";

        for (int i = 1; i <= Rooms.Count; i++)
        {
            result += PrintRoom(i);

            if (i < Rooms.Count)
            {
                result += Environment.NewLine;
            }            
        }
        return result;
    }

    public string PrintRoom(int number)
    {
        if (Rooms[number] == null)
        {
            return "Room empty";
        }
        else
        {
            return Rooms[number].ToString();
        }
    }

    public bool HasEmptyRooms()
    {
        return Rooms.Values.Any(val => val == null);
    }
}
