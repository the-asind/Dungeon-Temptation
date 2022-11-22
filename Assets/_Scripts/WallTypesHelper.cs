using System.Collections.Generic;

public static class WallTypesHelper
{
    /*
     * This "Magical numbers" is simple enough. It is like translator for engine "that walls you need to put".
     * In code below you can see exact matching of each number with each type of wall-tile
     * 
     * Calculation of the walls is in relation to each floor.
     * Where 0 mean lack of floor in the neighborhood and 1 is its presence.
     * The search starts like a clock: clockwise from the top (top, right, bottom, left).
     * Then the resulting zeros and ones are written in binary format and sent to this repeater.
     *
     * Просчет стен происходит по отношению к каждому полу. Где 0 - отсутствие пола по соседству, а 1 - его наличие.
     * Поиск идёт как часы: от вверха и по часовой стрелке (вверх, право, низ, лево). Затем итоговые нули и единицы
     * записываются в бинарном формате и передаются в этот ретранслатор.
     */
    public static readonly HashSet<byte> WallTop = new()
    {
        0b1111,
        0b0110,
        0b0011,
        0b0010,
        0b1010,
        0b1100,
        0b1110,
        0b1011,
        0b0111
    };

    public static readonly HashSet<byte> WallSideLeft = new()
    {
        0b0100
    };

    public static readonly HashSet<byte> WallSideRight = new()
    {
        0b0001
    };

    public static readonly HashSet<byte> WallBottom = new()
    {
        0b1000
    };

    /*
     * Similar semantics: the passage is also diagonal, but ideologically identical to the variant above in the code.
     * Схожая семантика: проход идёт также и по диагонали, но идейно идентичен варианту выше по коду.
     */
    public static readonly HashSet<byte> WallInnerCornerDownLeft = new()
    {
        0b11110001,
        0b11100000,
        0b11110000,
        0b11100001,
        0b10100000,
        0b01010001,
        0b11010001,
        0b01100001,
        0b11010000,
        0b01110001,
        0b00010001,
        0b10110001,
        0b10100001,
        0b10010000,
        0b00110001,
        0b10110000,
        0b00100001,
        0b10010001
    };

    public static readonly HashSet<byte> WallInnerCornerDownRight = new()
    {
        0b11000111,
        0b11000011,
        0b10000011,
        0b10000111,
        0b10000010,
        0b01000101,
        0b11000101,
        0b01000011,
        0b10000101,
        0b01000111,
        0b01000100,
        0b11000110,
        0b11000010,
        0b10000100,
        0b01000110,
        0b10000110,
        0b11000100,
        0b01000010
    };

    public static readonly HashSet<byte> WallDiagonalCornerDownLeft = new()
    {
        0b01000000
    };

    public static readonly HashSet<byte> WallDiagonalCornerDownRight = new()
    {
        0b00000001
    };

    public static readonly HashSet<byte> WallDiagonalCornerUpLeft = new()
    {
        0b00010000,
        0b01010000
    };

    public static readonly HashSet<byte> WallDiagonalCornerUpRight = new()
    {
        0b00000100,
        0b00000101
    };

    public static readonly HashSet<byte> WallFull = new()
    {
        0b1101,
        0b0101,
        0b1101,
        0b1001
    };

    public static readonly HashSet<byte> WallFullEightDirections = new()
    {
        0b00010100,
        0b11100100,
        0b10010011,
        0b01110100,
        0b00010111,
        0b00010110,
        0b00110100,
        0b00010101,
        0b01010100,
        0b00010010,
        0b00100100,
        0b00010011,
        0b01100100,
        0b10010111,
        0b11110100,
        0b10010110,
        0b10110100,
        0b11100101,
        0b11010011,
        0b11110101,
        0b11010111,
        0b11010111,
        0b11110101,
        0b01110101,
        0b01010111,
        0b01100101,
        0b01010011,
        0b01010010,
        0b00100101,
        0b00110101,
        0b01010110,
        0b11010101,
        0b11010100,
        0b10010101
    };

    public static readonly HashSet<byte> WallBottomEightDirections = new()
    {
        0b01000001
    };
    //offtop: в unity есть свой генератор стен, который работает, вероятно, даже лучше этого.
    //Но пусть используется этот, как показатель программистской части проекта.
}